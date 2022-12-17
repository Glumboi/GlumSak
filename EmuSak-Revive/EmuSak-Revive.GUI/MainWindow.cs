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
using EmuSak_Revive.Audio;
using System.Xml.Linq;
using System.Diagnostics;

namespace EmuSak_Revive.GUI
{
    public partial class MainWindow : Form
    {
        public bool DoneLoading { get; private set; }
        public static int EmuConfig { get; private set; }

        private List<BunifuImageButton> bunifuImageButtons = new List<BunifuImageButton>();

        /*public static int WindowVolume
        { get => (int)mainWindowPlayer.Volume * 100; set { mainWindowPlayer.Volume = value; } }*/

        private ConfigurationWindow configureWindow = new ConfigurationWindow();
        private GangShitWindow gangShitWindow = new GangShitWindow();
        private SettingsWindow settingsWindow = new SettingsWindow();
        private AboutWindow aboutWindow = new AboutWindow();
        public static AudioPlayer mainWindowPlayer = new AudioPlayer(Properties.Settings.Default.MainWindowVolume);
        public static DebugConsole debugConsole = new DebugConsole(2, "Glumsak debug console", false, false);

        private List<string> iconUrls = new List<string>();
        private List<string> ids = new List<string>();
        private List<string> names = new List<string>();
        private List<string> firmwareVersions = new List<string>();

        private int clickCount = 0; //For the lil easter egg
        private string firmwareToDownload = string.Empty;
        private readonly Timer cooldownTimer = new Timer();

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

        private void LoadScrollbar()
        {
            if (Games_FlowPanel.Controls.Count <= 9)
            {
                Games_ScrollBar.Hide();
            }
            else
            {
                Games_ScrollBar.Show();
            }
        }

        private void LoadSoundFiles()
        {
            try
            {
                mainWindowPlayer.AudioFiles = new List<string>()
                {
                    Environment.CurrentDirectory + @"\Audio\enter_back.wav",
                    Environment.CurrentDirectory + @"\Audio\select.wav"
                };
            }
            catch (Exception)
            {
                //Do nothing
            }
        }

        public void InitSettings()
        {
            LangLoader.Run();
            cooldownTimer.Tick += CooldownTimer_Tick;
            cooldownTimer.Interval = 3000;
            Networking.DownloadProgressBar = Download_ProgressBar;
            Download_ProgressBar.Visible = false;
            Networking.MainWindowHandle = this.Handle;

            LoadFirmwares();
            CheckShaderUrl();
        }

        private void LoadEmuIcon()
        {
            if (EmuConfig == 0)
            {
                
            }
        }

        private void CheckShaderUrl()
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

        private void LoadFirmwares()
        {
            //https://archive.org/download/nintendo-switch-global-firmwares/Firmware%201.0.0.zip
            firmwareVersions = Networking.GetFirmwareVersions().Distinct().ToList();

            foreach (var v in firmwareVersions.OrderByDescending(VersionSorter.OrderVersion))
            {
                Debug.WriteLine(v);
                Firmware_DropDown.Items.Add(v);
            }

            Firmware_DropDown.SelectedIndex = 0;

            debugConsole.Info($"Firmwares loaded!, Amount of combobox items: {Firmware_DropDown.Items.Count}");
        }

        private void LoadStandardPresence()
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
            LoadSoundFiles();
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

        private void CreateButton(
            string name,
            string imageUrl,
            string tag,
            bool useImage = false,
            Image btnImage = null)
        {
            Image img = null;
            if (!useImage)
            {
                img = Networking.CreateImageFromURL(imageUrl);
            }
            else
            {
                img = btnImage;
            }

            BunifuImageButton btn = new BunifuImageButton();
            btn.Name = name;
            btn.Image = img;

            //btn.AllowZooming = false;
            btn.Size = new Size(155, 155); //Original size: 130
            btn.FadeWhenInactive = true;
            btn.BorderStyle = BorderStyle.None;
            btn.MouseDown += GameButtonClicked;
            btn.MouseHover += Btn_MouseHover; ;
            btn.Tag = tag;

            Games_FlowPanel.Controls.Add(btn);
            bunifuImageButtons.Add(btn);
            debugConsole.Info($"Created a button with the id: {btn.Name}");
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            PlayAudio.Play(mainWindowPlayer,
                Properties.Settings.Default.PlaySounds,
                mainWindowPlayer.AudioFiles[1]);
        }

        private void LoadGamesToUI(int config)
        {
            List<string> fileLines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Python/gameIcons_Ids.txt").ToList();

            for (int i = 0; i < fileLines.Count; i++)
            {
                string line = fileLines[i];
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
                        if (!gameName.Contains("Pokémon"))
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
                        CreateButton(gameId, icon, gameName);
                    }
                }
            }

            LoadScrollbar();

            List<Image> images = new List<Image>();
            List<string> names = new List<string>();
            List<string> ids = new List<string>();

            foreach (var item in bunifuImageButtons)
            {
                images.Add(item.Image);
                ids.Add(item.Name);
                names.Add(item.Tag.ToString());
            }

            GlumSakCache.CreateGlumSakCache(images, names, ids, config);
        }

        public void LoadWithCache()
        {
            GlumSakCache.GetCacheContent();
            var gameImgs = GlumSakCache.GameImgs;
            var gameNames = GlumSakCache.GameNames;
            var gameIds = GlumSakCache.GameIds;

            LoadPortableEmus();
            if (GlumSakCache.EmuConfig == "Yuzu")
            {
                ChangeEmuConfig(0);
                Yuzu.GetGames();
            }
            else
            {
                ChangeEmuConfig(1);
                Ryujinx.GetGames();
            }

            for (int i = 0; i < gameNames.Count; i++)
            {
                CreateButton(gameNames[i], "", gameIds[i], true, gameImgs[i]);
            }
            DoneLoading = true;
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

        private string gameId = string.Empty;
        private string gameName = string.Empty;
        private Image gameImg = null;

        private void GameButtonClicked(object sender, MouseEventArgs e)
        {
            gameId = (sender as BunifuImageButton).Name;
            gameName = (sender as BunifuImageButton).Tag.ToString();
            gameImg = (sender as BunifuImageButton).Image;

            PlayAudio.Play(mainWindowPlayer,
            Properties.Settings.Default.PlaySounds,
            mainWindowPlayer.AudioFiles[0]);

            GameActionsWindow gameActionsWindow = new GameActionsWindow();
            gameActionsWindow.Text = gameName;//buttonID;
            gameActionsWindow.Init(gameImg, gameName, gameId);
            gameActionsWindow.Show();
        }

        //For later development
        private void ShadersItem_Click(object sender, EventArgs e)
        {
            GameActionsWindow.DownloadShader(gameName, gameId);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            debugConsole.SaveLog(true, "./GlumSakLog.txt");
            Application.Exit();
        }

        private void Configure_Button_Click(object sender, EventArgs e)
        {
            settingsWindow.Show();
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
                EmuKeys.InstallKeys(0, Yuzu.PortableYuzu);
            }

            if (EmuConfig == 1)
            {
                EmuKeys.InstallKeys(1, Ryujinx.PortableRyujinx);
            }
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            Temporary.DeleteTemporaryFiles();

            MessageBox.Show("Deleted all temporary files.\nThis includes the last sessions cache aswell as any temp files that GlumSak created.");
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
            Task.Run(() =>
            {
                EmuFirmware.InstallFirmware(EmuConfig, Networking.GetFirmwareDownload(firmwareToDownload));
            });
        }

        private void Games_FlowPanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                Games_FlowPanel.VerticalScroll.Value = e.NewValue;
            }
        }

        private void ResetFilter()
        {
            foreach (var item in Games_FlowPanel.Controls.OfType<BunifuImageButton>())
            {
                item.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    item.Visible = true;
                });
            }
        }

        private void FilterGames(string filter)
        {
            foreach (var item in Games_FlowPanel.Controls.OfType<BunifuImageButton>())
            {
                if (!item.Tag.ToString().ToLower().Contains(filter))
                {
                    item.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        item.Visible = false;
                    });
                }
            }
        }

        private void Filter_TextBox_TextChanged(object sender, EventArgs e)
        {
            //We use task and ivoke to make sure the UI stays responsive while filtering
            Task.Run(() =>
            {
                if (!string.IsNullOrWhiteSpace(Filter_TextBox.Text.ToLower()))
                {
                    ResetFilter();
                    FilterGames(Filter_TextBox.Text.ToLower());
                }

                if (string.IsNullOrWhiteSpace(Filter_TextBox.Text))
                {
                    ResetFilter();
                }
            });
        }

        private void RemoveFilter_Button_Click(object sender, EventArgs e)
        {
            Filter_TextBox.Text = string.Empty;
        }
    }
}