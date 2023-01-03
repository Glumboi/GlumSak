using Bunifu.UI.WinForms;
using EmuSak_Revive.ConfigIni.Core;
using EmuSak_Revive.JSON;
using Glumboi.UI;
using Octokit;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using EmuSak_Revive.GUI.Properties;

namespace EmuSak_Revive.GUI
{
    public partial class UpdateWindow : Form
    {
        private IniParser iniParser = new IniParser("./updaterConfig.ini");
        private string jsonFileName = string.Empty;
        private string exeFileName = string.Empty;

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void UpdateWindow_Load(object sender, EventArgs e)
        {
            UIChanger.ChangeTitlebarToDark(Handle);
            CheckOnStartup_CheckBox.Checked = Settings.Default.CheckForUpdatesOnStartup;
        }

        private void Button_No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Yes_Click(object sender, EventArgs e)
        {
            StartUpdateProcess();
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
                GitHubToken = "Your-Token-Here";
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
                    Progress_CircleBar.Visible = true;
                    PleaseWait_label.Visible = true;

                    string[] stringsForAnimation = {
                        "Please wait",
                        "Please wait.",
                        "Please wait..",
                        "Please wait..."
                    };

                    AnimateText textAnimator = new AnimateText(PleaseWait_label, stringsForAnimation, 300);
                    textAnimator.Run();

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
            Environment.Exit(0);
        }

        private void WebClient2_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress_CircleBar.Value = e.ProgressPercentage;
        }

        private void UpdateWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.CheckForUpdatesOnStartup = CheckOnStartup_CheckBox.Checked;
            Settings.Default.Save();
        }
    }
}