using System;
using System.Drawing;
using System.Windows.Forms;
using EmuSak_Revive.GUI.Generics;
using EmuSak_Revive.Network;
using EmuSak_Revive.Emulators;
using Bunifu.UI.WinForms;
using EmuSak_Revive.JSON;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using EmuSak_Revive.EmuFiles;
using Glumboi.Debug;
using System.Threading.Tasks;
using EmuSak_Revive.Discord;
using Glumboi.UI;
using Transitions;
using System.Text;

namespace EmuSak_Revive.GUI
{
    public partial class MainWindow : Form
    {
        public bool DoneLoading { get; private set; }
        public static int EmuConfig { get; private set; }

        ConfigurationWindow configureWindow = new ConfigurationWindow();
        GangShitWindow gangShitWindow = new GangShitWindow();
        SettingsWindow settingsWindow = new SettingsWindow();
        AboutWindow aboutWindow = new AboutWindow();
        public static DebugConsole debugConsole = new DebugConsole(2, "Glumsak debug console", false, false);

        List<string> iconUrls = new List<string>();
        List<string> ids = new List<string>();
        List<string> names = new List<string>();
        List<string> firmwareVersions = new List<string>();

        int clickCount = 0; //For the lil easter egg
        string firmwareToDownload = string.Empty;
        Timer cooldownTimer = new Timer();

        Bitmap[] happyGifs =
        {
            Properties.Resources.HappyBird_Asset,
            Properties.Resources.PeepoHappy_Asset,
            Properties.Resources.CatDance_Asset,
            Properties.Resources.HappyCat_Asset,
            Properties.Resources.RabbitVibe_Asset,
            Properties.Resources.DrogaDog_Asset,
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadPortableEmus()
        {
            if (settingsWindow.PortableRyujinx)
            {
                Ryujinx.ChangePortablePath(settingsWindow.PortableRyujinxPath);
                debugConsole.Info($"Loaded portable Ryujinx config, path: {settingsWindow.PortableRyujinxPath}");
            }

            if (settingsWindow.PortableYuzu)
            {
                Yuzu.ChangePortablePath(settingsWindow.PortableYuzuPath);
                debugConsole.Info($"Loaded portable Yuzu config, path: {settingsWindow.PortableYuzuPath}");
            }
        }

        public void InitSettings()
        {
            cooldownTimer.Tick += CooldownTimer_Tick;
            cooldownTimer.Interval = 3000;
            Networking.DownloadProgressBar = Download_ProgressBar;
            Download_ProgressBar.Visible = false;
            LoadFirmwares();
            CheckShaderUrl();
        }

        void CheckShaderUrl()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.ShaderLinks))
            {
                MessageBox.Show("There is no link given in the settings to download shaders from!\n" +
                    "This will result into non working shaders. Make sure to set a pastebin link up in the settings," +
                    " or any raw file on the web.\n\n" +
                    "If you have a working link verify the format. It has to look like this: " +
                    "Gamename=https://linktoshader.zip\nImportant is that it needs to be in the exact format.",
                    "Important",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(Networking.ShaderUrl))
            {
                Networking.ShaderUrl = Properties.Settings.Default.ShaderLinks;
            }
        }

        void LoadFirmwares()
        {
            firmwareVersions = Networking.GetFirmwareVersions().Distinct().ToList();
            foreach (string item in firmwareVersions)
            {
                Firmware_DropDown.Items.Add(item);
            }
            var highestVersion = Max(Networking.Versions.ToArray());
            for (int i = 0; i < Firmware_DropDown.Items.Count; i++)
            {
                object dropItem = Firmware_DropDown.Items[i];
                var itemText = dropItem.ToString();
                if (itemText.Contains(highestVersion.ToString()))
                {
                    Firmware_DropDown.SelectedIndex = i;
                }
            }

            debugConsole.Info($"Firmwares loaded!, Amount of combobox items: {Firmware_DropDown.Items.Count}");
        }

        void LoadStandardPresence()
        {
            RichPresence richPresence = new RichPresence();
            richPresence.Init();
            richPresence.UpdatePresence(
                $"Doing things in {this.Text}",
                "In MainWindow",
                "big",
                "small",
                "GlumSak");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            UI.ChangeToDarkMode(this);
            LoadStandardPresence();
            InitSettings();
        }

        public void ChangeEmuConfig(int config)
        {
            EmuConfig = config;
            if (config == 0)
                this.Text = "GlumSak (Yuzu)";
            if (config == 1)
                this.Text = "GlumSak (Ryujinx)";
            if (Ryujinx.PortableRyujinx && config == 1)
                this.Text = "GlumSak (Ryujinx portable)";
            if (Yuzu.PortableYuzu && config == 0)
                this.Text = "GlumSak (Yuzu portable)";
        }

        private void GetIconsAndIds()
        {
            List<string> fileLines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Python/gameIcons_Ids.txt").ToList();

            foreach (var fileLine in fileLines)
            {
                if (!fileLine.Contains("null"))
                {
                    var splitFileLine = fileLine.Split(new[] { "|" }, StringSplitOptions.None);

                    var iconUrl = splitFileLine[0].Split('\"')[1];
                    var id = splitFileLine[1].Split('\"')[1];
                    var name = splitFileLine[2].Split('\"')[1];
                    ids.Add(id);
                    iconUrls.Add(iconUrl);
                    names.Add(name);
                }

            }
        }

        private void CreateButton(string name, string imageUrl, string tag)
        {
            var img = Networking.CreateImageFromURL(imageUrl);

            BunifuImageButton btn = new BunifuImageButton();
            btn.Name = name;
            btn.Image = img;

            btn.AllowZooming = false;
            btn.Size = new Size(145, 145); //Original size: 130
            btn.FadeWhenInactive = true;
            btn.BorderStyle = BorderStyle.None;
            btn.Click += GameButtonClicked;
            btn.Tag = tag;

            Games_FlowPanel.Controls.Add(btn);

            debugConsole.Info($"Created a button with the id: {btn.Name}");
        }

        void LoadGamesToUI(int config)
        {
            List<string> fileLines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Python/gameIcons_Ids.txt").ToList();

            foreach (string line in fileLines)
            {
                if (!line.Contains("null"))
                {
                    string fileGameID = line.Split('\"')[3];
                    string icon = line.Split('\"')[1];
                    string gameId = fileGameID.Split('|')[0];
                    string gameNameRaw = line.Split('\"')[5];
                    string[] gameNameSplitted = new string[] { };
                    string gameName = string.Empty;

                    if (gameNameRaw.Contains(@"\u2122"))
                    {
                        gameNameSplitted = gameNameRaw.Split(new string[] { @"\u2122" }, StringSplitOptions.None);
                    }

                    //This whole branch is intended to clean up pokemon game titles
                    if (gameNameRaw.Contains(@"Pok\u00e9mon"))
                    {
                        string[] pokemon = gameNameRaw.Split(new string[] { @"Pok\u00e9mon\u2122" }, StringSplitOptions.None);
                        string pokemonNew = "Pokémon";

                        if (gameNameRaw.Contains(@"Let\u2019s"))
                        {
                            string[] lets = gameNameRaw.Split(new string[] { @"Let\u2019s" }, StringSplitOptions.None);
                            string letsNew = "Let's";
                            gameName = pokemonNew + letsNew + lets[1];
                        }
                        else if (gameNameRaw.Contains(@"\u2122"))
                        {
                            var pokeSplitted = gameNameRaw.Split(new string[] { @"\u2122" }, StringSplitOptions.None);
                            gameName = pokemonNew + pokeSplitted[1];
                        }
                        else
                        {
                            gameName = pokemonNew + pokemon.Last();
                        }
                    }

                    if (gameNameSplitted.Length > 0 && !gameNameSplitted.Contains("Pok\\u00e9mon"))
                    {
                        gameName = gameNameSplitted[0] + gameNameSplitted[1];
                    }
                    else
                    {
                        if(!gameName.Contains("Pokémon"))
                            gameName = gameNameRaw;
                    }

                    bool condition = false;
                    if (config == 0)
                    {
                        condition = Yuzu.Games.Contains(gameId);
                    }
                    if (config == 1)
                    {
                        condition = Ryujinx.Games.Contains(gameId);
                    }

                    if (condition)
                    {
                        CreateButton(gameId, icon, gameName);//gameId, icon);
                    }
                }
            }
        }

        public void LoadButtons()
        {
            Json.Run("https://raw.githubusercontent.com/blawar/titledb/master/US.en.json");
            GetIconsAndIds();

            if (EmuConfig == 0)
            {
                LoadGamesToUI(0);
            }

            if (EmuConfig == 1)
            {
                LoadGamesToUI(1);
            }

            DoneLoading = true;
        }

        private void GameButtonClicked(object sender, EventArgs e)
        {
            string buttonID = (sender as BunifuImageButton).Name;
            Image buttonImg = (sender as BunifuImageButton).Image;
            string buttonTag = (sender as BunifuImageButton).Tag.ToString();

            GameActionsWindow gameActionsWindow = new GameActionsWindow();
            gameActionsWindow.Text = buttonTag;//buttonID;
            gameActionsWindow.Init(buttonImg, buttonTag, buttonID);
            gameActionsWindow.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            debugConsole.SaveLog(true, "./GlumSakLog.txt");
            Application.Exit();
        }

        private void Configure_Button_Click(object sender, EventArgs e)
        {
            settingsWindow.Show();
            //configureWindow.Show();
        }

        private void Discord_Button_Click(object sender, EventArgs e)
        {
            Networking.LaunchURLInBrowser("https://discord.gg/sinscove");
        }

        private void About_Button_Click(object sender, EventArgs e)
        {
            if (!aboutWindow.Visible)
            {
                aboutWindow.Show();
            }

            clickCount++;
            if (!cooldownTimer.Enabled) cooldownTimer.Start();

            if (clickCount == 5)
            {
                ShowGangShit();
                clickCount = 0;
                cooldownTimer.Stop();
            }
        }

        private void CooldownTimer_Tick(object sender, EventArgs e)
        {
            clickCount = 0;
        }

        private void ShowGangShit()
        {
            gangShitWindow.Show();
        }

        private void Keys_Button_Click(object sender, EventArgs e)
        {
            if (EmuConfig == 0)
            {
                EmuKeys.InstallYuzuKeys();
            }

            if (EmuConfig == 1)
            {
                EmuKeys.InstallRyuKeys();
            }
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            Temporary.DeleteTemporaryFiles();

            MessageBox.Show("Deleted all temporary files");
        }

        private void Firmware_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            firmwareToDownload = this.Firmware_DropDown.GetItemText(this.Firmware_DropDown.SelectedItem);
        }

        public static int Max(params int[] values)
        {
            return Enumerable.Max(values);
        }

        private void DownloadFirmware_Button_Click(object sender, EventArgs e)
        {
            //Server URL: http://carltschober.phoebe.feralhosting.com/links/GlussySac/ => not used atm

            Task.Run(() =>
            {
                EmuFirmware.InstallFirmware(EmuConfig, Networking.GetFirmwareDownload(firmwareToDownload));
            });
        }

        private void Games_FlowPanel_Scroll(object sender, ScrollEventArgs e)
        {
            Games_FlowPanel.Invalidate();
        }
    }
}
