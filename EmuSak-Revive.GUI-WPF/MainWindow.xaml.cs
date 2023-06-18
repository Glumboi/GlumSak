using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Dialogs;

using EmuSak_Revive.GUI_WPF.Extensions;
using EmuSak_Revive.GUI_WPF.ExtraWindows;
using EmuSak_Revive.Network;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.JSON;

using Wpf.Ui.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using EmuSak_Revive.Plugins;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EmuSak_Revive.GUI_WPF.PluginExtra;
using Wpf.Ui.Appearance;
using EmuSak_Revive.GUI_WPF.CustomControls;
using Wpf.Ui.Common;

namespace EmuSak_Revive.GUI_WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        #region Public properties

        public bool DoneLoading { get; private set; }
        public static int EmuConfig { get; private set; }
        public string PortableYuzuPath { get => Properties.Settings.Default.PortableYuzuPath; }
        public string PortableRyujinxPath { get => Properties.Settings.Default.PortableRyujinxpath; }
        public string ShaderUrl { get => Properties.Settings.Default.ShaderLinks; }
        public bool PortableYuzu { get => Properties.Settings.Default.PortableYuzu; }
        public bool PortableRyujinx { get => Properties.Settings.Default.PortableRyujinx; }

        #endregion Public properties

        #region List variables

        private List<string> iconUrls = new List<string>();
        private List<string> ids = new List<string>();
        private List<string> names = new List<string>();
        private List<string> firmwareVersions = new List<string>();
        private List<SwitchGame> switchGames = new List<SwitchGame>();
        private List<CardExpander> imageButtons = new List<CardExpander>();

        #endregion List variables

        #region Private local variables

        private string firmwareToDownload = string.Empty;
        private string autorunFile = "./AutorunPlugins.txt";
        private IntPtr windowHandle;

        #endregion Private local variables

        public MainWindow()
        {
            InitializeComponent();
            windowHandle = new WindowInteropHelper(this).Handle;
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitSettings();
        }

        public void InitSettings()
        {
            Networking.DownloadBorder = Progress_Border;
            Networking.DownloadProgressBar = Download_ProgressBar;
            Networking.DownloadProgressText = DownloadProgress_TextBlock;
            Progress_Border.Visibility = Visibility.Collapsed;

            LoadFirmwares();
            CheckShaderUrl(); //--> Checks if a valid paste is entered
            LoadYuzuEarlyAccessBuilds();
            CheckYuzuStartup();

            //Visual settings
            this.Height = Properties.Settings.Default.LastHeight;
            this.Width = Properties.Settings.Default.LastWidth;

            //Settings page
            YuzuPath_TextBox.Text = Properties.Settings.Default.PortableYuzuPath;
            RyuPath_TextBox.Text = Properties.Settings.Default.PortableRyujinxpath;
            PasteBinUrl_TextBox.Text = Properties.Settings.Default.ShaderLinks;
            CheckForAppUpdates_CheckBox.IsChecked = Properties.Settings.Default.CheckForUpdatesOnStartup;

            //Yuzu updater
            YuzuBinariesPath_TextBox.Text = Properties.Settings.Default.YuzuBinariesPath;
            YuzuStartupUpdateCheck_CheckBox.IsChecked = Properties.Settings.Default.CheckForYuzuUpdateOnStartup;

            //Snack
            SnackDuration_Slider.Value = Properties.Settings.Default.SnackBarTimeout;

            Networking.NotificationSnackBar = Notification_SnackBar;

            AllowPlugins_Switch.IsChecked = Properties.Settings.Default.AllowPlugins;

            LoadPlugins();
        }

        private void SaveSettings() //--> Saves a bunch of settings
        {
            Properties.Settings.Default.PortableYuzuPath = string.IsNullOrWhiteSpace(YuzuPath_TextBox.Text) ? string.Empty : YuzuPath_TextBox.Text;
            Properties.Settings.Default.PortableYuzu = !string.IsNullOrWhiteSpace(YuzuPath_TextBox.Text);
            Properties.Settings.Default.PortableRyujinxpath = string.IsNullOrWhiteSpace(RyuPath_TextBox.Text) ? string.Empty : RyuPath_TextBox.Text;
            Properties.Settings.Default.PortableRyujinx = !string.IsNullOrWhiteSpace(RyuPath_TextBox.Text);

            if (Decode.IsBase64(PasteBinUrl_TextBox.Text))
            {
                byte[] data = Convert.FromBase64String(PasteBinUrl_TextBox.Text);
                string decodedString = Encoding.UTF8.GetString(data);
                Properties.Settings.Default.ShaderLinks = decodedString;
            }
            else
            {
                Properties.Settings.Default.ShaderLinks = PasteBinUrl_TextBox.Text;
            }

            Extensions.SetWindowSize.ChangeLastSizeOfMainWindow(this);

            Properties.Settings.Default.CheckForUpdatesOnStartup = (bool)CheckForAppUpdates_CheckBox.IsChecked;
            Properties.Settings.Default.YuzuBinariesPath = YuzuBinariesPath_TextBox.Text;
            Properties.Settings.Default.CheckForYuzuUpdateOnStartup = (bool)YuzuStartupUpdateCheck_CheckBox.IsChecked;

            //Snack
            Properties.Settings.Default.SnackBarTimeout = Notification_SnackBar.Timeout;
            Properties.Settings.Default.Save();

            //Plugins
            Properties.Settings.Default.AllowPlugins = (bool)AllowPlugins_Switch.IsChecked;
            CreatePluginAutorunFile();

            Networking.ShowNotification("Saved the Settings with Success!");
        }

        private void CreatePluginAutorunFile()
        {
            List<string> pluginNames = PluginHelpers.autorunPlugins.Select(s => s.PluginName).ToList();
            File.Delete(autorunFile);
            File.WriteAllLines(autorunFile, pluginNames);
        }

        private void CheckShaderUrl()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.ShaderLinks))
            {
                Notification_SnackBar.Content = "No Paste detected in the Settings!";
                Notification_SnackBar.Show();
                return;
            }
            if (string.IsNullOrWhiteSpace(Networking.PasteURL))
            {
                Networking.PasteURL = Properties.Settings.Default.ShaderLinks;
            }
        }

        private void LoadYuzuEarlyAccessBuilds()
        {
            Yuzu.GetYuzuEABuilds();
            foreach (var item in Yuzu.YuzuEAVersions)
            {
                YuzuVersions_DropDown.Items.Add(item);
            }

            YuzuVersions_DropDown.SelectedIndex = 0;
        }

        private void CheckYuzuStartup()
        {
            if (Properties.Settings.Default.CheckForYuzuUpdateOnStartup)
            {
                CheckForYuzuUpdate();
            }
        }

        private async void CheckForYuzuUpdate(bool showUptodateNotification = false)
        {
            string localVer = null; // Used to store the return value
            await System.Threading.Tasks.Task.Run(() =>
            {
                localVer = string.Empty;

                YuzuBinariesPath_TextBox.Dispatcher.Invoke(new Action(delegate
                {
                    localVer = Yuzu.GetYuzuBinaryVersion(YuzuBinariesPath_TextBox.Text);
                }));
            });

            if (localVer == string.Empty) return;

            string newestVersion = YuzuVersions_DropDown.Items[0].ToString();

            if (Yuzu.IsLocalYuzuOutdated(localVer, newestVersion))
            {
                MessageBoxResult dialogResult = System.Windows.MessageBox.Show(
                    $"There is a newer version of yuzu-ea!" +
                    $"\nCurrent version: {localVer}" +
                    $"\nNewest version: {newestVersion}" +
                    $"\nDo you want to install it now?",
                    "Yuzu update avialable!",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    UpdateYuzu();
                }
            }

            if (showUptodateNotification)
            {
                Networking.ShowNotification("Congrats, your yuzu version is up to date!");
            }
        }

        private void UpdateYuzu()
        {
            if (string.IsNullOrWhiteSpace(YuzuBinariesPath_TextBox.Text))
            {
                Networking.ShowNotification("The Yuzu Binaries Path can't be empty!", Wpf.Ui.Common.SymbolRegular.ErrorCircle24);

                return;
            }

            int index = YuzuVersions_DropDown.SelectedIndex;
            var fileLink = Yuzu.GetYuzuEADDL(Yuzu.YuzuEAVersionsLinks[index]);
            Networking.DownloadAFileFromServer(fileLink,
                Temporary.TempPath +
                $"tempYuzu{YuzuVersions_DropDown.SelectedItem.ToString()}" +
                $".Sak",
                YuzuBinariesPath_TextBox.Text,
                true,
                true,
                true,
                true,
                "yuzu-windows-msvc-early-access");
        }

        private void CheckForYuzuUpdates_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckForYuzuUpdate(true);
        }

        private void DownloadYuzuVersion_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateYuzu();
        }

        private void Filter_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var gameButtons = Games_Panel.Children.OfType<GameButton>();
            var visibilities = Filtering.Buttons.GetButtonsToHide(gameButtons, Filter_TextBox.Text);

            for (int i = 0; i < visibilities.Count(); i++)
            {
                gameButtons.ElementAt(i).Visibility = visibilities.ElementAt(i);
            }
        }

        private void ClearFilter_Button_Click(object sender, RoutedEventArgs e)
        {
            Filter_TextBox.Text = string.Empty;
        }

        private void LoadFirmwares()
        {
            firmwareVersions = Networking.GetFirmwareVersions().Distinct().ToList();

            foreach (var v in firmwareVersions.OrderByDescending(VersionSorter.OrderVersion))
            {
                Debug.WriteLine(v);
                Firmware_ComboBox.Items.Add(v);
            }

            Firmware_ComboBox.SelectedIndex = 0;
        }

        private CardExpander CreateGameButtonFromMetaLine(string line)
        {
            string fileGameID = line.Split('\"')[3];
            string icon = line.Split('\"')[1];
            string gameId = fileGameID.Split('|')[0];
            string gameName = line.Split('\"')[5];
            SwitchGame game = new SwitchGame(gameName, gameId, icon);
            switchGames.Add(game);

            ids.Add(fileGameID);
            names.Add(gameName);
            return CreateButton(game);
        }

        private void LoadGamesToUI(int config)
        {
            IEnumerable<string> fileLines = File.ReadLines("./Json/gameIcons_Ids.txt");
            List<string> games = config == 0 ? Yuzu.Games : Ryujinx.Games;

            foreach (var line in fileLines)
            {
                foreach (var game in games)
                {
                    if (!line.Contains(game)) continue;

                    imageButtons.Add(CreateGameButtonFromMetaLine(line));
                }
            }
            GlumSakCache.CreateGlumSakCache(switchGames, config);
        }

        private CardExpander CreateButton(SwitchGame game, System.Drawing.Image btnImage = null)
        {
            var gameBtn = new GameButton(game);
            Games_Panel.Children.Add(gameBtn);
            return gameBtn;
        }

        public void LoadPortableEmus()
        {
            if (this.PortableRyujinx)
            {
                Ryujinx.ChangePortablePath(PortableRyujinxPath);
            }

            if (this.PortableYuzu)
            {
                Yuzu.ChangePortablePath(PortableYuzuPath);
            }
        }

        public void ChangeEmuConfig(int config)
        {
            EmuConfig = config;

            if (config == 0)
            {
                TitleBar.Title = "GlumSak (Yuzu)";
            }
            if (config == 1)
            {
                TitleBar.Title = "GlumSak (Ryujinx)";
            }
            if (Ryujinx.PortableRyujinx && config == 1)
            {
                TitleBar.Title = "GlumSak (Ryujinx portable)";
            }
            if (Yuzu.PortableYuzu && config == 0)
            {
                TitleBar.Title = "GlumSak (Yuzu portable)";
            }
        }

        public async void LoadButtons()
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                Json.Run("https://raw.githubusercontent.com/blawar/titledb/master/US.en.json");
                GetIconsAndIds();
            });

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

        private void GetIconsAndIds()
        {
            IEnumerable<string> fileLines = File.ReadLines("./Json/gameIcons_Ids.txt");

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
                SwitchGame game = new SwitchGame(gameNames[i], gameIds[i], "", gameImgs[i]);
                CreateButton(game, gameImgs[i]);
                switchGames.Add(game);
            }
            DoneLoading = true;
        }

        private void UiWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
            System.Windows.Application.Current.Shutdown();
        }

        private void SaveSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Firmware_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firmwareToDownload = this.Firmware_ComboBox.SelectedItem.ToString();
        }

        private void DownloadFirmware_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                EmuFirmware.InstallFirmware(EmuConfig, Networking.GetFirmwareDownload(firmwareToDownload));
            });
        }

        private void Keys_Button_Click(object sender, RoutedEventArgs e)
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

        private void OpenFolder(System.Windows.Controls.TextBox pathBox) //--> Opens a folder and sets the path to a bunifutextbox
        {
            var opener = new CommonOpenFileDialog { IsFolderPicker = true };

            if (opener.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pathBox.Text = opener.FileName;
            }
        }

        private void SelectYuzuBinariesFolder_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFolder(YuzuBinariesPath_TextBox);
        }

        private void SelectYuzuPath_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFolder(YuzuPath_TextBox);
        }

        private void SelectRyujinxPath_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFolder(RyuPath_TextBox);
        }

        private void DeleteTempFiles_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("This will delete all GlumSak temp Files, do you want to proceed?",
                "Info",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            if (dialogResult == MessageBoxResult.Yes)
            {
                Temporary.DeleteTemporaryFiles();
                Networking.ShowNotification("Deleted all temp files of GlumSak!", Wpf.Ui.Common.SymbolRegular.Delete28);
            }
        }

        private void RestartApp()
        {
            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("This will restart GlumSak!\nAre you sure?", "Info",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (dialogResult == MessageBoxResult.Yes)
            {
                ConfigurationWindow configurationWindow = new ConfigurationWindow();
                configurationWindow.Show();

                var exePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = exePath + @"\GlumSak.exe";
                    process.StartInfo.Verb = "runas";
                    process.Start();
                }
                Close();
            }
        }

        private void ResetApp()
        {
            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("The settings are now gonna be reset!\n" +
                                                        "Are you sure? This will also clear any temporary files.",
                                                        "Info",
                                                         MessageBoxButton.YesNo,
                                                         MessageBoxImage.Warning);

            if (dialogResult == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                InitSettings();
                Temporary.DeleteTemporaryFiles();
                Networking.ShowNotification("GlumSak got reset!", Wpf.Ui.Common.SymbolRegular.ArrowReset24);
            }

            return;
        }

        private void RestartApp_Button_Click(object sender, RoutedEventArgs e)
        {
            RestartApp();
        }

        private void ResetApp_Button_Click(object sender, RoutedEventArgs e)
        {
            ResetApp();
        }

        private void GlumSakGithub_Button_Click(object sender, RoutedEventArgs e)
        {
            Networking.LaunchURLInBrowser("https://github.com/Glumboi/GlumSak");
        }

        private void EmuSakUIGithub_Button_Click(object sender, RoutedEventArgs e)
        {
            Networking.LaunchURLInBrowser("https://github.com/CapitaineJSparrow/emusak-ui");
        }

        private void PasteBinUrl_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Networking.PasteURL = PasteBinUrl_TextBox.Text;
        }

        private void CancelDownload_Button_Click(object sender, RoutedEventArgs e)
        {
            Networking.CancelDownload();
        }

        private void SnackDuration_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Notification_SnackBar != null)
            {
                double sliderInSecs = SnackDuration_Slider.Value / 1000;
                string sliderInSecsString = sliderInSecs.ToString("00");

                SnackDuration_TextBlock.Text = $"Snackbar display Duration: {sliderInSecsString} Seconds";
                Notification_SnackBar.Timeout = (int)SnackDuration_Slider.Value;
            }
        }

        private void MainTabs_TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainTabs_TabControl.SelectedIndex)
            {
                case 0:
                    AnimateControl("SpinHomeImage");
                    break;

                case 1:
                    AnimateControl("SpinInfoImage");
                    break;

                case 2:
                    AnimateControl("SpinSettingsImage");
                    break;

                case 3:
                    AnimateControl("SpinNewsImage");
                    break;

                case 4:
                    AnimateControl("SpinPluginsImage");
                    break;
            }
        }

        private void AnimateControl(string storyBoardName)
        {
            Storyboard s = (Storyboard)TryFindResource(storyBoardName);
            s.Begin();
        }

        private void LoadAutorunPlugins()
        {
            if (!File.Exists(autorunFile)) return;

            foreach (var line in File.ReadLines(autorunFile))
            {
                PluginHelpers.autorunPlugins.Add(PluginHelpers.GetPluginByName(line));
            }

            foreach (var item in PluginHelpers.autorunPlugins)
            {
                if (item != null)
                {
                    item.ExecutePlugin();
                }
            }
        }

        private void LoadPlugins()
        {
            windowHandle = new WindowInteropHelper(this).Handle;

            if (!Properties.Settings.Default.AllowPlugins)
            {
                Plugins_Tab.Visibility = Visibility.Collapsed;
                return;
            }

            string pluginsLocation = AppDomain.CurrentDomain.RelativeSearchPath ??
                AppDomain.CurrentDomain.BaseDirectory + "Plugins";

            if (Directory.Exists(pluginsLocation))
            {
                foreach (Plugin plugin in PluginHelpers.GetPlugins(pluginsLocation, windowHandle))
                {
                    PluginHelpers.plugins.Add(plugin);
                }
                LoadAutorunPlugins();
                CreatePluginListItems();
            }
        }

        private void CreatePluginListItems()
        {
            foreach (Plugin plugin in PluginHelpers.plugins)
            {
                bool isAutorun = PluginHelpers.autorunPlugins.Contains(plugin);
                CreatePluginListItem(plugin, isAutorun);
            }
        }

        private void CreatePluginListItem(Plugin plugin, bool autoRun)
        {
            ListViewItem item = new ListViewItem();
            item.Focusable = false;
            item.Visibility = Visibility.Visible;

            var card = new PluginCard(plugin, autoRun);
            item.Content = card;
            Plugins_ListView.Items.Add(item);
        }
    }
}