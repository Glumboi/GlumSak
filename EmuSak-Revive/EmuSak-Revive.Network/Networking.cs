using Glumboi.UI.Toast;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.WindowsAPICodePack.Taskbar;
using AnonFileAPI;
using System.Drawing.Drawing2D;
using System.Windows.Controls;
using System.Windows.Threading;
using Wpf.Ui.Controls;
using System.Xml.Linq;

namespace EmuSak_Revive.Network
{
    public static class Networking
    {
        #region Public properties

        public static bool DownloadDone => _downloadDone;
        public static IntPtr MainWindowHandle { get; set; }
        public static List<int> Versions => versionsList;
        public static string PasteURL { get; set; }
        public static System.Windows.Controls.ProgressBar DownloadProgressBar { get; set; }
        public static TextBlock DownloadProgressText { get; set; }
        public static Border DownloadBorder { get; set; }
        public static string LastDownloadMeta => _lastDownloadMeta + "\n";
        public static Snackbar NotificationSnackBar { get; set; }

        #endregion Public properties

        #region Private variables

        /// <summary>
        /// Variables used for the download progress changed
        /// </summary>
        private static List<int> versionsList = new List<int>();

        private static Stopwatch sw = new Stopwatch();  // The stopwatch which we will be using to calculate the download speed
        private static string _unzipPath = string.Empty;
        private static string _outPathName = string.Empty;
        private static bool _showStartNotification = true;
        private static bool _showFinishNotification = true;
        private static bool _deleteTempAfterDone = true;
        private static bool _downloadDone = false;
        private static long _totalBytesReceived;
        private static bool _filesInFolder;
        private static string _childFolderName;
        private static string _currentWebFile;
        private static readonly Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();
        private static string _lastDownloadMeta;
        private static WebClient _client;

        #endregion Private variables

        public static void ShowDownloadDone(string downloadDoneMsg, string title)
        {
            ToastHandler.ShowToast(downloadDoneMsg, title);
        }

        public static void ShowNotification(string content, Wpf.Ui.Common.SymbolRegular icon = Wpf.Ui.Common.SymbolRegular.Info28)
        {
            NotificationSnackBar.Dispatcher.Invoke(new Action(delegate
            {
                NotificationSnackBar.Icon = icon;
                NotificationSnackBar.Content = content;
                NotificationSnackBar.Show();
            }), DispatcherPriority.Normal);
        }

        private static string GetPasteContent()
        {
            using (WebClient client = new WebClient())
            {
                if (!string.IsNullOrWhiteSpace(PasteURL))
                {
                    try
                    {
                        var contentBytes = client.OpenRead(PasteURL);
                        StreamReader reader = new StreamReader(contentBytes);
                        string content = reader.ReadToEnd();
                        return content;
                    }
                    catch
                    {
                        //File could not be read from the web, try to see if the file is local
                        if (File.Exists(PasteURL))
                        {
                            var content = File.ReadAllText(PasteURL);

                            return content;
                        }

                        ShowNotification($"Somethimg went wrong while trying to get something from the Paste.\nMake sure that you have a valid Paste!",
                            Wpf.Ui.Common.SymbolRegular.ErrorCircle24);
                    }
                }
            }

            return null;
        }

        private static string GetPasteValue(char splitChar, string gameName, int index)
        {
            string result = string.Empty;
            string pasteResult = GetPasteContent();
            string pasteContent = !string.IsNullOrWhiteSpace(pasteResult) ? pasteResult : string.Empty;

            if (pasteContent != string.Empty)
            {
                using (var sr = new StringReader(pasteContent))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(gameName) && line.Contains(splitChar))
                        {
                            result = line.Split(splitChar)[index];
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets all shader files from a raw text file
        /// format of the trxt file has to be:
        /// Mario Kart 8 Deluxe=https://thelinktotheshader.zip
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetShaderDownload(string gameName)
        {
            return GetPasteValue('=', gameName, 1);
        }

        public static string GetPasteGameShaderCount(string gameName)
        {
            string count = GetPasteValue('|', gameName, 1);
            if (count == string.Empty)
            {
                return "0";
            }

            return count;
        }

        /// <summary>
        /// Parses the given archive.org link with the firmwares and slpits the returned url and returns the result
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static string GetFirmwareDownload(string version)
        {
            return ParseLinks("https://archive.org/download/nintendo-switch-global-firmwares")
                [0].Split(new char[] { '#' })[0]
                + "/Firmware%20" + version.Split(new char[] { ' ' })[1]
                + ".zip";
        }

        public static IEnumerable<string> NaturalSort(IEnumerable<string> list)
        {
            int maxLen = list.Select(s => s.Length).Max();
            Func<string, char> PaddingChar = s => char.IsDigit(s[0]) ? ' ' : char.MaxValue;

            return list
                    .Select(s =>
                        new
                        {
                            OrgStr = s,
                            SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, PaddingChar(m.Value)))
                        })
                    .OrderBy(x => x.SortStr)
                    .Select(x => x.OrgStr);
        }

        private static string GetAbsoluteUrlString(string baseUrl, string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
                uri = new Uri(new Uri(baseUrl), uri);
            return uri.ToString();
        }

        /// <summary>
        /// Parses a websites content and gets any links from the site and outputs them (used for archive.org)
        /// </summary>
        /// <param name="urlToCrawl"></param>
        /// <returns></returns>
        ///
        public static List<string> ParseLinks(string urlToCrawl)
        {
            List<string> hrefs = GetHrefs(urlToCrawl);
            HashSet<string> result = new HashSet<string>();

            foreach (var href in hrefs)
            {
                result.Add(GetAbsoluteUrlString(urlToCrawl, href));
            }
            return result.ToList();
        }

        /// <summary>
        /// This gets all firmwares from a archive.org site
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFirmwareVersions()
        {
            List<string> linksToVisit = ParseLinks(@"https://archive.org/download/nintendo-switch-global-firmwares");
            List<string> rtrnList = new List<string>();

            foreach (var item in linksToVisit)
            {
                var splitted = item.Split(new string[] { ".zip" }, StringSplitOptions.None);
                var firmwareVersions = splitted[0].Split('/');
                //var sorted = NaturalSort(firmwareVersions).ToArray(); => Disabled for testing purposes
                foreach (var version in firmwareVersions)
                {
                    if (version.Contains("Firmware") && !version.Contains("%") && !version.Contains("MD5"))
                    {
                        var itemToAdd = version.Split(new string[] { "Firmware" }, StringSplitOptions.None)[1];
                        rtrnList.Add(itemToAdd);
                        Versions.Add(Int32.Parse(itemToAdd.Split('.')[0]));
                    }
                }
            }
            return rtrnList;
        }

        /// <summary>
        /// Launches a URL in the browser
        /// </summary>
        /// <param name="link"></param>
        public static void LaunchURLInBrowser(string link)
        {
            try
            {
                Process.Start(link);
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    System.Windows.MessageBox.Show(noBrowser.Message);
            }
            catch (Exception other)
            {
                System.Windows.MessageBox.Show(other.Message);
            }
        }

        /// <summary>
        /// Downloads and compresses an image from a given url
        /// </summary>
        /// <param name="url">Image url</param>
        /// <param name="maxWidth">Desired width of the image</param>
        /// <param name="maxHeight">Desired height of the image</param>
        /// <returns>Returns a compressed image from the given url in the desired hieight and width</returns>
        public static Bitmap LoadImageFromUrl(string url, int maxWidth, int maxHeight)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream responseStream = httpWebResponse.GetResponseStream();

            using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(responseStream))
            {
                int newWidth = originalImage.Width;
                int newHeight = originalImage.Height;

                // Scale the image down if it is larger than the maximum size
                if (originalImage.Width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)(originalImage.Height * ((float)maxWidth / originalImage.Width));
                }
                if (newHeight > maxHeight)
                {
                    newHeight = maxHeight;
                    newWidth = (int)(originalImage.Width * ((float)maxHeight / originalImage.Height));
                }

                // Create a new Bitmap object with the scaled size
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);
                using (Graphics graphics = Graphics.FromImage(newBitmap))
                {
                    // Draw the original image onto the new Bitmap object with the scaled size
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                }

                return newBitmap;
            }
        }

        /// <summary>
        /// Unzips a file and replaces it if it exists already
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outPath"></param>
        /// <param name="deleteAfterDone"></param>
        public static void Unzip(
            string inputFile,
            string outPath,
            bool deleteAfterDone = true,
            bool filesInFolder = false,
            string childFolderName = "")
        {
            using (ZipArchive source = ZipFile.Open(inputFile, ZipArchiveMode.Read, null))
            {
                foreach (ZipArchiveEntry entry in source.Entries)
                {
                    string fullPath = Path.GetFullPath(Path.Combine(outPath, entry.FullName));

                    if (Path.GetFileName(fullPath).Length != 0)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                        // The boolean parameter determines whether an existing file that has the same name as the destination file should be overwritten
                        entry.ExtractToFile(fullPath, true);
                    }
                }

                source.Dispose();
            }

            if (filesInFolder)
            {
                CopyFilesRecursively(childFolderName, outPath);

                Directory.Delete(childFolderName, true);
            }

            if (deleteAfterDone)
            {
                File.Delete(inputFile);
            }
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        public static List<string> GetAllLinksFromGithubReleases(string site)
        {
            string expandedReleases = site.Replace("releases/tag", "releases/expanded_assets");

            var doc = new HtmlWeb().Load(expandedReleases);
            var linkTags = doc.DocumentNode.Descendants("link");
            var linkedPages = doc.DocumentNode.Descendants("a")
                                              .Select(a => a.GetAttributeValue("href", null))
                                              .Where(u => !string.IsNullOrEmpty(u));
            var res = new List<string>();

            foreach (var item in linkedPages)
            {
                res.Add("https://github.com" + item);
            }

            return res;
        }

        /// <summary>
        /// Used to download a file from the web with a trackable progress
        /// </summary>
        /// <param name="url"></param>
        /// <param name="outPathName"></param>
        /// <param name="unzipPath"></param>
        /// <param name="showFinishedNotification"></param>
        /// <param name="showStartedNotification"></param>
        /// <param name="deleteTempAfterDone"></param>
        public static void DownloadAFileFromServer(
            string url,
            string outPathName,
            string unzipPath,
            bool showFinishedNotification = true,
            bool showStartedNotification = true,
            bool deleteTempAfterDone = true,
            bool filesInFolder = false,
            string childFolderName = "")
        {
            //If link in paste is an anonfiles link, convert it to ddl with the AnonFileWrapper
            if (url.Contains("anonfiles"))
            {
                var tempUrl = url;
                using (AnonFileWrapper afwAnonFileWrapper = new AnonFileWrapper())
                {
                    url = (afwAnonFileWrapper.GetDirectDownloadLinkFromLink(tempUrl));
                }
            }

            if (url.Contains("mediafire"))
            {
                var tempUrl = url;
                url = ConvertMediaFireToDDL(tempUrl);
            }

            if (DownloadBorder.Visibility == System.Windows.Visibility.Visible)
            {
                ShowNotification("You are already downloading something, please wait for the download to finish!");
                _downloadDone = false;
                return;
            }

            _client = new WebClient();

            _client.DownloadProgressChanged += Client_DownloadProgressChanged;
            _client.DownloadFileCompleted += Client_DownloadFileCompleted;
            _client.DownloadFileAsync(new Uri(url, UriKind.Absolute), outPathName);

            _unzipPath = unzipPath;
            _outPathName = outPathName;
            _showFinishNotification = showFinishedNotification;
            _showStartNotification = showStartedNotification;
            _deleteTempAfterDone = deleteTempAfterDone;
            _stopWatch.Start(); // Start the Stopwatch
            _downloadDone = false;
            _totalBytesReceived = 0;
            _filesInFolder = filesInFolder;
            _childFolderName = unzipPath + "\\" + childFolderName;
            _currentWebFile = url.Split('/').Last();

            if (_showStartNotification)
            {
                ShowNotification($"Started download of the file: {_currentWebFile}", Wpf.Ui.Common.SymbolRegular.ArrowDownload24);
            }
            ShowProgressBar();
        }

        /// <summary>
        /// Cancels the current File Download
        /// </summary>
        public static void CancelDownload()
        {
            _client.CancelAsync();
        }

        /// <summary>
        /// Changes the current text of the progressbar
        /// </summary>
        /// <param name="text"></param>
        private static void ChangeProgressText(string text)
        {
            DownloadProgressText.Dispatcher.Invoke(new Action(delegate
            {
                DownloadProgressText.Text = text;
            }), DispatcherPriority.Normal);
        }

        /// <summary>
        /// Updates the current value of the progressbar
        /// </summary>
        /// <param name="progress"></param>
        private static void UpdateProgress(int progress)
        {
            DownloadProgressBar.Dispatcher.Invoke(new Action(delegate
            {
                DownloadProgressBar.Value = progress;
            }), DispatcherPriority.Normal);
        }

        /// <summary>
        /// Shows the given progressbar (used when the download starts)
        /// </summary>
        private static void ShowProgressBar()
        {
            DownloadBorder.Dispatcher.Invoke(new Action(delegate
            {
                DownloadBorder.Visibility = System.Windows.Visibility.Visible;
            }), DispatcherPriority.Normal);
        }

        /// <summary>
        /// Hides the given progressbar (used when the download finishes)
        /// </summary>
        private static void HideProgressBar()
        {
            DownloadBorder.Dispatcher.Invoke(new Action(delegate
            {
                DownloadBorder.Visibility = System.Windows.Visibility.Collapsed;
            }), DispatcherPriority.Normal);
        }

        /// <summary>
        /// Gets executed when the progress of an ongoing download from a fileserver finishes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ResetProgress();
                File.Delete(_outPathName);
                ShowNotification($"Cancelled the Download of {_currentWebFile}", Wpf.Ui.Common.SymbolRegular.Delete28);
                HideProgressBar();
                return;
            }

            Unzip(_outPathName, _unzipPath, _deleteTempAfterDone, _filesInFolder, _childFolderName);
            if (_showFinishNotification)
            {
                ShowNotification($"Finished the Installation of {_currentWebFile}", Wpf.Ui.Common.SymbolRegular.Checkmark28);
            }

            ResetProgress();
        }

        /// <summary>
        /// Resets all Values that interact with the UI
        /// </summary>
        private static void ResetProgress()
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, MainWindowHandle);

            UpdateProgress(0);
            HideProgressBar();

            _stopWatch.Reset();
            _downloadDone = true;
            _client.Dispose();
        }

        /// <summary>
        /// Used to ensure that the filesize is displayed without a . or , in any language
        /// </summary>
        /// <param name="totalBytes"></param>
        /// <returns></returns>
        private static string GetFileSizeWithoutComma(double totalBytes)
        {
            if (totalBytes.ToString().Contains(","))
            {
                return totalBytes.ToString().Split(',')[0];
            }

            return totalBytes.ToString().Split('.')[0];
        }

        /// <summary>
        /// Gets executed when the progress of an ongoing download from a fileserver changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            int percentageString = int.Parse(Math.Truncate(percentage).ToString());
            UpdateProgress(percentageString);

            //Used to display a progressbar on the taskbar
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, MainWindowHandle);
            TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100, MainWindowHandle);

            // Calculate progress values
            double fileSize = totalBytes / 1024.0 / 1024.0;
            double downloadSpeed = e.BytesReceived / 1024.0 / 1024.0 / _stopWatch.Elapsed.TotalSeconds;

            //Calculate ETA
            double remainingBytes = totalBytes - bytesIn;
            double remainingTime = remainingBytes / (downloadSpeed * 1024 * 1024);
            string remainingTimeString = TimeSpan.FromSeconds(remainingTime).ToString(@"hh\:mm\:ss");

            string progressBarText = string.Format("{0} MB/s | {1}: {2} MB | ETA: {3}",
                downloadSpeed.ToString("0.00"),
                "File Size",
                GetFileSizeWithoutComma(fileSize),
                remainingTimeString);

            ChangeProgressText(progressBarText);
        }

        /// <summary>
        /// Downloads keys from google drive
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="destinationPath"></param>
        public static void DownloadKeys(string URL, string destinationPath)
        {
            GDriveDownloader driveDownloader = new GDriveDownloader();
            driveDownloader.DownloadFile(URL, destinationPath);
        }

        public static string ConvertMediaFireToDDL(string sourceURL)
        {
            foreach (string item in GetHrefs(sourceURL))
            {
                if (item.Contains("https://download"))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets all hrefs in a website
        /// </summary>
        /// <param name="url">Source url</param>
        /// <returns></returns>
        public static List<string> GetHrefs(string url)
        {
            // declaring & loading dom
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(url);
            List<string> resultList = new List<string>();

            // extracting all links
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];

                if (att.Value.Contains("a"))
                {
                    resultList.Add(att.Value);
                }
            }

            return resultList;
        }
    }
}