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
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Configuration;
using System.Reflection;
using EmuSak_Revive.Language;
using Glumboi.UI.Toast;

namespace EmuSak_Revive.GUI.New
{
    public partial class MainWindow : Form
    {
        public bool DoneLoading { get; private set; }
        public static int EmuConfig { get; private set; }
        public string PortableYuzuPath { get => Properties.Settings.Default.PortableYuzuPath; }
        public string PortableRyujinxPath { get => Properties.Settings.Default.PortableRyujinxpath; }
        public string ShaderUrl { get => Properties.Settings.Default.ShaderLinks; }
        public bool PortableYuzu { get => Properties.Settings.Default.PortableYuzu; }
        public bool PortableRyujinx { get => Properties.Settings.Default.PortableRyujinx; }

        private List<BunifuImageButton> bunifuImageButtons = new List<BunifuImageButton>();

        private GangShitWindow gangShitWindow = new GangShitWindow();
        private SettingsWindow settingsWindow = new SettingsWindow();
        private AboutWindow aboutWindow = new AboutWindow();
        public static AudioPlayer mainWindowPlayer = new AudioPlayer(Properties.Settings.Default.MainWindowVolume);

        public static DebugConsole debugConsole = new DebugConsole(Properties.Settings.Default.LogLevel,
                                                      "Glumsak debug console",
                                                      Properties.Settings.Default.DebugMode,
                                                      Properties.Settings.Default.CatchErros);

        private List<string> iconUrls = new List<string>();
        private List<string> ids = new List<string>();
        private List<string> names = new List<string>();
        private List<string> firmwareVersions = new List<string>();

        private int clickCount = 0; //For the lil easter egg
        private string firmwareToDownload = string.Empty;
        private readonly Timer cooldownTimer = new Timer();
        private Dictionary<BunifuLabel, Point> originalPositions; //Used for label calculation

        public MainWindow()
        {
            InitializeComponent();
            Networking.AssignDebugConsole(debugConsole);
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

        private void LoadSoundFiles()
        {
            if (Directory.Exists(Environment.CurrentDirectory + @"\Audio"))
            {
                mainWindowPlayer.AudioFiles = new List<string>()
                {
                    Environment.CurrentDirectory + @"\Audio\enter_back.wav",
                    Environment.CurrentDirectory + @"\Audio\select.wav"
                };
            }
        }

        private void LoadAllTabs()
        {
            int origTab = TabControl.SelectedIndex;

            for (int i = 0; i < TabControl.TabCount; i++) // --> Goes through all tabs and opens them
                                                          // so they load the UI controls
            {
                TabControl.SelectedIndex = i;
            }

            TabControl.SelectedIndex = origTab;
        }

        public void InitSettings()
        {
            //Other
            LoadAllTabs();
            InitLang();
            cooldownTimer.Tick += CooldownTimer_Tick;
            cooldownTimer.Interval = 3000;
            Networking.DownloadProgressBar = Download_ProgressBar;
            Download_ProgressBar.Visible = false;
            Networking.MainWindowHandle = this.Handle;
            LoadEmuIcon();
            LoadFirmwares();
            CheckShaderUrl();

            //Window settings
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Size = new Size(Properties.Settings.Default.LastWidth, Properties.Settings.Default.LastHeight);

            //Settings page
            YuzuPath_TextBox.Text = Properties.Settings.Default.PortableYuzuPath;
            RyuPath_TextBox.Text = Properties.Settings.Default.PortableRyujinxpath;
            PasteBinUrl_TextBox.Text = Properties.Settings.Default.ShaderLinks;
            PlaySounds_CheckBox.Checked = Properties.Settings.Default.PlaySounds;
            MainWindow_AudioSlider.Value = Properties.Settings.Default.MainWindowVolume;
            CheckOnStartup_CheckBox.Checked = Properties.Settings.Default.CheckForUpdatesOnStartup;

            //Debug settings
            DebugMode_CheckBox.Checked = Properties.Settings.Default.DebugMode;
            CatchErros_CheckBox.Checked = Properties.Settings.Default.CatchErros;
            LogLevel_DropDown.SelectedIndex = Properties.Settings.Default.LogLevel;

            UpdateSliderValLabel();
        }

        public void InitLang()
        {
            LoadLanguages();

            /*try --> Old version of the code
            {
                Language_DropDown.SelectedIndex = Properties.Settings.Default.SelectedLanguage;
            }
            catch (Exception)
            {
                return;
            }*/

            int index = Properties.Settings.Default.SelectedLanguage;
            if (index < 0 || index >= Language_DropDown.Items.Count)
            {
                index = 0; // Set to default value
            }
            Language_DropDown.SelectedIndex = index;
        }

        private void LoadLanguages()
        {
            Lang.LoadLanguageConfigs();
            foreach (var str in Lang.Languages.Distinct())
            {
                Language_DropDown.Items.Add(str);
            }
        }

        private void UpdateSliderValLabel()
        {
            MainWindowVolume_Label.Text = MainWindow_AudioSlider.Value.ToString();
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
        }

        private void LoadEmuIcon()
        {
            MainTab.ImageIndex = EmuConfig;
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
            LoadOriginalLabelLocs();
            LoadSoundFiles();
            LoadStandardPresence();
            InitSettings();
            LoadControlsAndStrings();
            ReloadScrollBar();
        }

        private void LoadOriginalLabelLocs()
        {
            originalPositions = new Dictionary<BunifuLabel, Point>();
            originalPositions[About_Label] = About_Label.Location;
            originalPositions[BugReport_Label] = BugReport_Label.Location;
            originalPositions[DebugSettings_Label] = DebugSettings_Label.Location;
        }

        private void LoadControlsAndStrings()
        {
            Controls_DataGrid.Rows.Clear();

            foreach (TabPage item in TabControl.TabPages)
            {
                System.Collections.IList list = item.Controls;
                for (int i = 0; i < list.Count; i++)
                {
                    Control c = (Control)list[i];
                    string[] row = new string[] { c.Name, c.Text };
                    Controls_DataGrid.Rows.Add(row);
                }
            }
        }

        public void ChangeEmuConfig(int config)
        {
            EmuConfig = config;

            if (config == 0)
            {
                Text = "GlumSak (Yuzu)";
            }
            if (config == 1)
            {
                Text = "GlumSak (Ryujinx)";
            }
            if (Ryujinx.PortableRyujinx && config == 1)
            {
                Text = "GlumSak (Ryujinx portable)";
            }
            if (Yuzu.PortableYuzu && config == 0)
            {
                Text = "GlumSak (Yuzu portable)";
            }
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

            Games_FlowPanel.Invoke((MethodInvoker)delegate //Used to fix a bug that causes infinite loading
            {
                Games_FlowPanel.Controls.Add(btn);
            });

            bunifuImageButtons.Add(btn);

            debugConsole.Info($"Created a button with the id: {btn.Name}");
        }

        private void GameContextClick(object sender, EventArgs e)
        {
            var item = sender as MenuItem;

            ShowGameActionsWindow(item.Name,
                item.Tag.ToString(),
                null);
        }

        private void GameButtonClicked(object sender, MouseEventArgs e)
        {
            var button = sender as BunifuImageButton;

            ShowGameActionsWindow(
                button.Name,
                button.Tag.ToString(),
                button.Image);
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
                    string cleaned = UnicodeDecoder.Decoder(gameNameRaw);

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
                        //gameName
                        CreateButton(gameId, icon, cleaned);
                    }
                }
            }

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

        private void ShowGameActionsWindow(string name, string tag, Image image)
        {
            gameId = name;
            gameName = tag;

            if (image != null)
            {
                gameImg = image;
            }

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
            SaveSettings();
            Environment.Exit(0);
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

        private void Language_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLanguage();
            LoadControlsAndStrings();
            Properties.Settings.Default.SelectedLanguage = Language_DropDown.SelectedIndex;
        }

        private void CalculateLabelLocs()
        {
            List<BunifuLabel> labels = new List<BunifuLabel>()
            {
                About_Label,
                BugReport_Label,
                DebugSettings_Label
            };

            foreach (var label in labels)
            {
                var x = originalPositions[label].X;
                var y = originalPositions[label].Y;

                var chars = label.Text.ToCharArray();

                var newX = x - chars.Length;
                label.Location = new Point(newX, y);
            }
        }

        private void UpdateLanguage()
        {
            CalculateLabelLocs();
            Lang.LoadLanguage(TabControl, Language_DropDown.SelectedIndex);
            UpdateExtraLangs();
        }

        private void UpdateExtraLangs()
        {
            Networking.TransLateFileSize(Language.Lang.GetSingeString("extraLang", "FileSizeString"));
        }

        private void SelectYuzuPath_Button_Click(object sender, EventArgs e)
        {
            OpenFolder(YuzuPath_TextBox);
        }

        private void OpenFolder(BunifuTextBox pathBox)
        {
            var opener = new CommonOpenFileDialog { IsFolderPicker = true };

            if (opener.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pathBox.Text = opener.FileName;
            }
        }

        private void SelectRyuPath_Button_Click(object sender, EventArgs e)
        {
            OpenFolder(RyuPath_TextBox);
        }

        private void MainWindow_AudioSlider_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            mainWindowPlayer.Volume = MainWindow_AudioSlider.Value / 100f;
            UpdateSliderValLabel();
        }

        private void SaveAndClose_Button_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.PortableYuzuPath = string.IsNullOrWhiteSpace(YuzuPath_TextBox.Text) ? string.Empty : YuzuPath_TextBox.Text;
            Properties.Settings.Default.PortableYuzu = !string.IsNullOrWhiteSpace(YuzuPath_TextBox.Text);
            Properties.Settings.Default.PortableRyujinxpath = string.IsNullOrWhiteSpace(RyuPath_TextBox.Text) ? string.Empty : RyuPath_TextBox.Text;
            Properties.Settings.Default.PortableRyujinx = !string.IsNullOrWhiteSpace(RyuPath_TextBox.Text);
            Properties.Settings.Default.ShaderLinks = PasteBinUrl_TextBox.Text;
            Networking.ShaderUrl = ShaderUrl;
            Properties.Settings.Default.PlaySounds = PlaySounds_CheckBox.Checked;
            Properties.Settings.Default.MainWindowVolume = MainWindow_AudioSlider.Value;
            Properties.Settings.Default.SelectedLanguage = Language_DropDown.SelectedIndex;
            Properties.Settings.Default.DebugMode = DebugMode_CheckBox.Checked;
            Properties.Settings.Default.CatchErros = CatchErros_CheckBox.Checked;
            Properties.Settings.Default.LogLevel = LogLevel_DropDown.SelectedIndex;
            Properties.Settings.Default.LastWidth = this.WindowState == FormWindowState.Maximized ? 1034 : this.Size.Width;
            Properties.Settings.Default.LastHeight = this.WindowState == FormWindowState.Maximized ? 550 : this.Size.Height;
            Properties.Settings.Default.CheckForUpdatesOnStartup = CheckOnStartup_CheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void EmuSakUI_Button_Click(object sender, EventArgs e)
        {
            Networking.LaunchURLInBrowser("https://github.com/CapitaineJSparrow/emusak-ui");
        }

        private void Github_Button_Click(object sender, EventArgs e)
        {
            Networking.LaunchURLInBrowser("https://github.com/Glumboi");
        }

        private void ReloadScrollBar()
        {
            Games_ScrollBar.BindingContainer = Games_FlowPanel; //To ensure that the scrolling always works
            Games_ScrollBar.ThumbSize = Games_FlowPanel.VerticalScroll.Maximum / 2;
            Debug.WriteLine($"New thumbsize: {Games_ScrollBar.ThumbSize}");
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            Debug.WriteLine("New size " + this.Size);
            ReloadScrollBar();
        }

        private void ClearLanguageSelector()
        {
            Language_DropDown.Items.Clear();
        }

        private void ResetSettings_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("The settings are now gonna be reset!\n" +
                "Are you sure? This will also clear any temporary files.",
                "Info",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                ClearLanguageSelector();
                InitSettings();
                Temporary.DeleteTemporaryFiles();
            }

            return;
        }

        private void PlaySounds_CheckBox_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            Properties.Settings.Default.PlaySounds = e.Checked;
        }

        private void RestartApp()
        {
            DialogResult dialogResult = MessageBox.Show("This will restart GlumSak!\nAre you sure?", "Info",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                ConfigurationWindow configurationWindow = new ConfigurationWindow();
                configurationWindow.Show();

                var exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = exePath + @"\GlumSak.exe";
                    process.StartInfo.Verb = "runas";
                    process.Start();
                }
                Close();
            }
        }

        private void Restart_Button_Click(object sender, EventArgs e)
        {
            RestartApp();
        }

        private void SendMail(string title, string content, string emailAddress)
        {
            content = content.Replace(System.Environment.NewLine, "%0d%0a");

            Process.Start("mailto:" + emailAddress + "?subject=" + title + "&body="
             + content + "%0d%0a%0d%0aMail from " + DateTime.Now);
        }

        private void SendFeedback_Button_Click(object sender, EventArgs e)
        {
            var fb = Feedback_TextBox.Text;
            var str = Rating.Value.ToString();

            SendMail("I gave GlumSak " +
                str +
                " stars because:",
                fb,
                "glumboi.contact@gmail.com");
        }

        private void SendBugReport_Button_Click(object sender, EventArgs e)
        {
            var rp = BugReport_TextBox.Text;
            var type = BugType_DropDown.SelectedItem.ToString();

            SendMail("I want to report a bug of the type " +
                type +
                " in GlumSak",
                rp,
                "glumboi.contact@gmail.com");
        }

        private void LogLevel_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            debugConsole.ChangeLevel(LogLevel_DropDown.SelectedIndex);
        }

        private void LoadSettingsToConsole_Button_Click(object sender, EventArgs e)
        {
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                var name = currentProperty.Name;
                var type = Properties.Settings.Default[currentProperty.Name].GetType();
                var value = Properties.Settings.Default[currentProperty.Name];
                var test = string.IsNullOrWhiteSpace(value.ToString()) ? "No Value" : value;
                debugConsole.Info("Value: " + test + " | Name:" + name + " | Type: " + type);
            }
        }

        private void LoadSelectedLangToConsole_button_Click(object sender, EventArgs e)
        {
            foreach (var item in Lang.GetLangIniSettings(Language_DropDown.SelectedIndex))
            {
                debugConsole.Info(item);
            }
        }

        private void SaveLog_Button_Click(object sender, EventArgs e)
        {
            debugConsole.SaveLog(true, "./GlumSakLog.txt");
            ToastHandler.ShowToast("Saved log to exe directory!", "Info");
        }
    }
}