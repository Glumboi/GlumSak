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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace EmuSak_Revive.Network
{
    public static class Networking
    {
        public static bool DownloadDone { get => _downloadDone; }
        public static string ShaderUrl { get; set; }
        public static RadProgressBar DownloadProgressBar { get; set; }
        public static List<int> Versions { get => versionsList; }
        static List<int> versionsList = new List<int>();

        static Stopwatch sw = new Stopwatch();  // The stopwatch which we will be using to calculate the download speed

        static string _unzipPath = string.Empty;
        static string _outPathName = string.Empty;
        static bool _showStartNotification = true;
        static bool _showFinishNotification = true;
        static bool _deleteTempAfterDone = true;
        static bool _downloadDone = false;
        private static readonly Stopwatch _stopwatch = new System.Diagnostics.Stopwatch();

        public static void ShowDownloadDone(string downloadDoneMsg, string title)
        {
            ToastHandler.ShowToast(downloadDoneMsg, title);
        }

        public static string GetShaderDownload(string name)
        {
            var result = string.Empty;

            WebClient client = new WebClient();

            if(!string.IsNullOrWhiteSpace(ShaderUrl))
            {
                try
                {
                    var contentBytes = client.OpenRead(ShaderUrl);
                    StreamReader reader = new StreamReader(contentBytes);
                    string content = reader.ReadToEnd();

                    using (var sr = new StringReader(content))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            // sth with a line
                            if (line.Contains(name))
                            {
                                result = line.Split('=')[1];
                            }
                        }
                    }

                    return result;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Couldn't load a shader from the given url in the settings!\n\nDetailed error: " + e,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            return string.Empty;
        }

        public static string GetFirmwareDownload(string version)
        {
            /*List<string> linksToVisit = ParseLinks("https://archive.org/download/nintendo-switch-global-firmwares");

            var baseUrl = linksToVisit[0];
            var baseSplitted = baseUrl.Split('#')[0];
            var firmware = baseSplitted + "/Firmware%20";
            var firmwareVersion = version;
            var firmwareVersionFinal = firmware + firmwareVersion.Split(' ')[1] + ".zip";

            return firmwareVersionFinal; => Disabled to test some things */

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

        static string GetAbsoluteUrlString(string baseUrl, string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
                uri = new Uri(new Uri(baseUrl), uri);
            return uri.ToString();
        }

        public static List<string> ParseLinks(string urlToCrawl)
        {
            WebClient webClient = new WebClient();

            byte[] data = webClient.DownloadData(urlToCrawl);
            string download = Encoding.ASCII.GetString(data);

            HashSet<string> list = new HashSet<string>();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(download);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a[@href]");

            foreach (var n in nodes)
            {
                string href = n.Attributes["href"].Value;
                list.Add(GetAbsoluteUrlString(urlToCrawl, href));
            }
            return list.ToList();
        }

        public static List<string> GetFirmwareVersions()
        {
            List<string> linksToVisit = ParseLinks("https://archive.org/download/nintendo-switch-global-firmwares");
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

        public static void LaunchURLInBrowser(string link)
        {
            try
            {
                Process.Start(link);
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        public static Image CreateImageFromURL(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebReponse.GetResponseStream();
            return Image.FromStream(stream);
        }

        public static void Unzip(string inputFile, string outPath, bool deleteAfterDone = true)
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

            if (deleteAfterDone)
            {
                File.Delete(inputFile);
            }
        }

        public static void DownloadAFileFromServer(
            string url,
            string outPathName,
            string unzipPath,
            bool showFinishedNotification = true,
            bool showStartedNotification = true,
            bool deleteTempAfterDone = true)
        {
            if (DownloadProgressBar.Visible)
            {
                ToastHandler.ShowToast("You are already downloading something, please wait for the download to finish!",
                    "Info");
                _downloadDone = false;
                return;
            }

            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                client.DownloadFileAsync(new Uri(url, UriKind.Absolute), outPathName);

                _unzipPath = unzipPath;
                _outPathName = outPathName;
                _showFinishNotification = showFinishedNotification;
                _showStartNotification = showStartedNotification;
                _deleteTempAfterDone = deleteTempAfterDone;
                _stopwatch.Start(); // Start the Stopwatch
                _downloadDone = false;

                if (_showStartNotification)
                {
                    ToastHandler.ShowToast("Started a download!", "Info");
                }

                ShowProgressBar();
            }
        }

        private static void ChangeProgressText(string text)
        {
            MethodInvoker mi = new MethodInvoker(() => DownloadProgressBar.Text = text);
            if (DownloadProgressBar.InvokeRequired)
            {
                DownloadProgressBar.Invoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }

        private static void UpdateProgress(int progress)
        {
            MethodInvoker mi = new MethodInvoker(() => DownloadProgressBar.Value1 = progress);
            if (DownloadProgressBar.InvokeRequired)
            {
                DownloadProgressBar.Invoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }

        private static void ShowProgressBar()
        {
            MethodInvoker mi = new MethodInvoker(() => DownloadProgressBar.Visible = true);
            if (DownloadProgressBar.InvokeRequired)
            {
                DownloadProgressBar.Invoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }

        private static void HideProgressBar()
        {
            MethodInvoker mi = new MethodInvoker(() => DownloadProgressBar.Visible = false);
            if (DownloadProgressBar.InvokeRequired)
            {
                DownloadProgressBar.Invoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }

        private static void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Unzip(_outPathName, _unzipPath, _deleteTempAfterDone);
            if (_showFinishNotification)
            {
                ToastHandler.ShowToast("A download finished!", "Info");
            }

            UpdateProgress(0);
            HideProgressBar();
            _stopwatch.Reset();
            _downloadDone = true;
        }

        private static void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //DownloadProgressBar.Value = e.ProgressPercentage;

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            UpdateProgress(int.Parse(Math.Truncate(percentage).ToString()));

            // Calculate progress values
            double fileSize = totalBytes / 1024.0 / 1024.0;
            string fileSizeStr = fileSize.ToString().Split(',')[0];

            string downloadSpeed = string.Format("{0} MB/s | File size: {1} MB",
                (e.BytesReceived / 1024.0 / 1024.0 / _stopwatch.Elapsed.TotalSeconds).ToString("0.00"),
                fileSizeStr);

            ChangeProgressText(downloadSpeed);
        }

        public static void DownloadKeys(string URL, string destinationPath)
        {
            GDriveDownloader driveDownloader = new GDriveDownloader();
            driveDownloader.DownloadFile(URL, destinationPath);
        }
    }
}
