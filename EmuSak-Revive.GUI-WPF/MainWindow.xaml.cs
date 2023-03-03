using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
using System.IO;
using EmuSak_Revive.GUI_WPF.Extensions;
using EmuSak_Revive.GUI_WPF.ExtraWindows;
using System.Diagnostics;
using EmuSak_Revive.Network;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.JSON;
using System.Windows.Interop;
using System.Reflection.Emit;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Threading;
using Glumboi.UI.Toast;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using System.Net.NetworkInformation;

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
        private List<System.Windows.Controls.Button> imageButtons = new List<System.Windows.Controls.Button>();

        #endregion List variables

        #region Private local variables

        private string firmwareToDownload = string.Empty;

        #endregion Private local variables

        public MainWindow()
        {
            InitializeComponent();
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
            Networking.MainWindowHandle = new WindowInteropHelper(this).Handle;

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

            Properties.Settings.Default.Save();
        }

        private void CheckShaderUrl()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.ShaderLinks))
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    System.Windows.MessageBox.Show("There is no link given in the settings to download shaders from!\n" +
                    "This will result into non working shaders. Make sure to set a pastebin link up in the settings," +
                    " or any raw file on the web.\n\n" +
                    "If you have a working link verify the format. It has to look like this: " +
                    "Gamename=https://linktoshader.zip\nImportant is that it needs to be in the exact format.",
                    "Important",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                });

                return;
            }
            if (string.IsNullOrWhiteSpace(Networking.ShaderUrl))
            {
                Networking.ShaderUrl = Properties.Settings.Default.ShaderLinks;
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
                ToastHandler.ShowToast("Congrats, your yuzu version is up to date!", "Yuzu is up to date");
            }
        }

        private void UpdateYuzu()
        {
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

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
            System.Windows.Controls.Image myButtonImage = btn.Content as System.Windows.Controls.Image;
            ImageSource imgSource = myButtonImage.Source;

            string gameID = btn.Tag.GetType().GetProperty("GameName").GetValue(btn.Tag, null).ToString();
            string gameName = btn.Tag.GetType().GetProperty("GameID").GetValue(btn.Tag, null).ToString();

            ShowGameActionsWindow(gameName, gameID, imgSource);
        }

        private void Filter_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<System.Windows.Controls.Button> buttons = Games_Panel.Children.OfType<System.Windows.Controls.Button>();
            foreach (var btn in buttons)
            {
                string gameName = btn.Tag.GetType().GetProperty("GameID").GetValue(btn.Tag, null).ToString();

                if (!gameName.ToLower().Contains(Filter_TextBox.Text.ToLower()))
                {
                    btn.Visibility = Visibility.Collapsed;
                }
                else
                {
                    btn.Visibility = Visibility.Visible;
                }
            }
        }

        private void ClearFilter_Button_Click(object sender, RoutedEventArgs e)
        {
            Filter_TextBox.Text = string.Empty;
        }

        private void LoadFirmwares()
        {
            //https://archive.org/download/nintendo-switch-global-firmwares/Firmware%201.0.0.zip
            firmwareVersions = Networking.GetFirmwareVersions().Distinct().ToList();

            foreach (var v in firmwareVersions.OrderByDescending(VersionSorter.OrderVersion))
            {
                Debug.WriteLine(v);
                Firmware_ComboBox.Items.Add(v);
            }

            Firmware_ComboBox.SelectedIndex = 0;
        }

        private void LoadGamesToUI(int config)
        {
            List<System.Drawing.Image> images = new List<System.Drawing.Image>();
            List<string> names = new List<string>();
            List<string> ids = new List<string>();

            string[] fileLines = File.ReadAllLines("./Json/gameIcons_Ids.txt");

            foreach (var line in fileLines)
            {
                if (!line.Contains("null"))
                {
                    string fileGameID = line.Split('\"')[3];
                    string icon = line.Split('\"')[1];
                    string gameId = fileGameID.Split('|')[0];
                    string gameName = line.Split('\"')[5];
                    System.Windows.Controls.Button currentBtn = new System.Windows.Controls.Button();
                    //string cleaned = UnicodeDecoder.Decoder(gameNameRaw); --> Deactivated due to being somewhat obsolete

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
                        currentBtn = CreateButton(gameId, icon, gameName);
                        imageButtons.Add(currentBtn);
                    }
                }
            }

            foreach (var item in imageButtons)
            {
                string gameID = item.Tag.GetType().GetProperty("GameName").GetValue(item.Tag, null).ToString();
                string gameName = item.Tag.GetType().GetProperty("GameID").GetValue(item.Tag, null).ToString();

                images.Add(Extensions.Imaging.ConvertButtonImageToSystemImage(item));
                ids.Add(gameID);
                names.Add(gameName);
            }
            GlumSakCache.CreateGlumSakCache(images, names, ids, config);
        }

        private string gameId = string.Empty;
        private string gameName = string.Empty;
        private ImageSource gameImg = null;

        private void ShowGameActionsWindow(string name, string tag, ImageSource image)
        {
            gameId = name;
            gameName = tag;

            if (image != null)
            {
                gameImg = image;
            }

            /* PlayAudio.PlayFromByteArr(mainWindowPlayer,
             Properties.Settings.Default.PlaySounds,
             Properties.Resources.enter_back);*/

            GameActionsWindow gameActionsWindow = new GameActionsWindow(name, tag, image);
            gameActionsWindow.Show();
        }

        private System.Windows.Controls.Button CreateButton(string name,
                    string imageUrl,
                    string tag,
                    bool useImage = false, //--> Not used in any way yet...
                    System.Drawing.Image btnImage = null)
        {
            System.Drawing.Image img = null;
            if (!useImage)
            {
                img = Networking.LoadImageFromUrl(imageUrl, 150, 150);
            }
            else
            {
                img = btnImage;
            }

            //var rounded = Imaging.RoundCorners(img, 15, System.Drawing.Color.Transparent);
            var imgSrc = Extensions.Imaging.ConvertToImageSource(img);

            System.Windows.Controls.Image btnImg = new System.Windows.Controls.Image();
            btnImg.Source = imgSrc;

            System.Windows.Controls.Button btn = new System.Windows.Controls.Button
            {
                Width = 24,
                Height = 24,
                Content = btnImg
            };

            Thickness m = btn.Margin;

            //Set Button margin
            m.Left = 4;
            m.Right = 4;
            m.Top = 4;
            m.Bottom = 4;

            btn.RenderSize = new System.Windows.Size(150, 150);
            btn.Height = 150;
            btn.Width = 150;
            btn.Margin = m;
            btn.Tag = new { GameName = name, GameID = tag };
            btn.Click += GameButton_Click;

            Games_Panel.Children.Add(btn);
            return btn;
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
            string[] fileLines = File.ReadAllLines("./Json/gameIcons_Ids.txt");

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
                CreateButton(gameNames[i], "", gameIds[i], true, gameImgs[i]);
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
                ToastHandler.ShowToast("Deleted all temp files of GlumSak!", "Info");
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
    }
}