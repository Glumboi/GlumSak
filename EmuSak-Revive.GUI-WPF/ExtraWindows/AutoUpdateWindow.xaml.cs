using EmuSak_Revive.ConfigIni.Core;
using EmuSak_Revive.Network;
using Octokit;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.GUI_WPF.ExtraWindows
{
    /// <summary>
    /// Interaktionslogik für AutoUpdateWindow.xaml
    /// </summary>
    public partial class AutoUpdateWindow : UiWindow
    {
        private IniParser iniParser = new IniParser("./updaterConfig.ini");
        private string jsonFileName = string.Empty;
        private string exeFileName = string.Empty;

        public AutoUpdateWindow()
        {
            InitializeComponent();
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Changelog_Browser.NavigateToString(VersionControl.Changelog);
            CheckForAppUpdates_CheckBox.IsChecked = Properties.Settings.Default.CheckForUpdatesOnStartup;
        }

        private async void StartUpdateProcess()
        {
            string workspaceName = iniParser.GetSetting("config", "author"); //"Glumboi";
            string repositoryName = iniParser.GetSetting("config", "repo");//"GlumSak";

            GitHubClient client = new GitHubClient(new Octokit.ProductHeaderValue(repositoryName));
            string GitHubToken = string.Empty;
            string configToken = iniParser.GetSetting("config", "githubToken");
            if (!string.IsNullOrWhiteSpace(configToken))
            {
                GitHubToken = configToken;
            }
            else
            {
            }

            Credentials tokenAuth = new Credentials(GitHubToken);
            client.Credentials = tokenAuth;

            // Retrieve a List of Releases in the Repository, and get latest using [0]-subscript
            var request = await client.Repository.Release.GetAll(workspaceName, repositoryName);
            var latest = request[0];
            var latestAsset = await client.Repository.Release.GetAllAssets("Glumboi", "GlumSak", latest.Id);

            using (WebClient webClient = new WebClient())
            {
                jsonFileName = iniParser.GetSetting("config", "jsonPath");
                exeFileName = iniParser.GetSetting("config", "exePath");

                webClient.Headers.Add("user-agent", "Anything");
                webClient.Headers.Add("authorization", "token " + GitHubToken);

                await webClient.DownloadFileTaskAsync(new Uri(latestAsset[0].Url), jsonFileName);

                string[] jsonContent = File.ReadAllLines(jsonFileName);
                string downloadLink = string.Empty;

                foreach (var line in jsonContent)
                {
                    if (line.Contains("browser_download_url"))
                    {
                        var splitted = line.Split(':');
                        var result = splitted[1] + splitted.Last();
                        downloadLink = result.Replace("\"", string.Empty).Replace("}", string.Empty).Replace("https//", "https://");
                    }
                }
                using (WebClient webClient2 = new WebClient())
                {
                    Progress_CircleBar.Visibility = Visibility.Visible;
                    PleaseWait_TextBlock.Visibility = Visibility.Visible;

                    webClient2.DownloadProgressChanged += WebClient2_DownloadProgressChanged;
                    webClient2.DownloadFileCompleted += WebClient2_DownloadFileCompleted;
                    await webClient2.DownloadFileTaskAsync(new Uri(downloadLink), exeFileName);
                }
            }
        }

        private void WebClient2_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Process.Start(exeFileName);
            File.Delete(jsonFileName);
            Close();
        }

        private void WebClient2_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress_CircleBar.Progress = e.ProgressPercentage;
        }

        private void Yes_Button_Click(object sender, RoutedEventArgs e)
        {
            StartUpdateProcess();
        }

        private void No_Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow configurationWindow = new ConfigurationWindow();
            configurationWindow.Show();
            Close();
        }

        private void CheckForAppUpdates_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.CheckForUpdatesOnStartup = true;
        }

        private void CheckForAppUpdates_CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.CheckForUpdatesOnStartup = false;
        }
    }
}