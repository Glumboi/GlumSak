using EmuSak_Revive.ConfigIni.Core;
using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI_WPF.Properties;
using EmuSak_Revive.Network;
using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.GUI_WPF.ExtraWindows
{
    /// <summary>
    /// Interaktionslogik für ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : UiWindow
    {
        private static IniParser iniParser = new IniParser("./updaterConfig.ini");

        private int _mode = 0;

        public ConfigurationWindow()
        {
            InitializeComponent();
        }

        private void CheckForUpdates()
        {
            /*var updateExe = iniParser.GetSetting("config", "exePath");
            if (File.Exists(updateExe))
            {
                File.Delete(updateExe);
            }

            bool isUpdateAvailable = VersionControl.CheckGitHubNewerVersion(Assembly.GetExecutingAssembly()).Result;//VersionControl.CheckGitHubNewerVersion(Assembly.GetExecutingAssembly()).Result;
            if (isUpdateAvailable && Settings.Default.CheckForUpdatesOnStartup)
            {
                AutoUpdateWindow updateWindow = new AutoUpdateWindow();
                updateWindow.Show();*/
            // updateWindow.CurrentVersion_Label.Text = Network.VersionControl.InstalledVersion.ToString();
            //updateWindow.NewVersion_Label.Text = Network.VersionControl.NewVersion.ToString();
            //}
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CheckForUpdates();
            GetSettings();
        }

        private void UiWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }

        private void GetSettings()
        {
            Cache_CheckBox.IsChecked = Properties.Settings.Default.UseLastSession;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.UseLastSession = (bool)Cache_CheckBox.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void Yuzu_Button_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(1);
        }

        private void LaunchApp(int mode)
        {
            LoadingWindow ls = new LoadingWindow();
            _mode = mode;
            if (mode == 0 && !(bool)Cache_CheckBox.IsChecked)
            {
                ls.Show();
                Close();
                ls.LaunchWithYuzuConfig();
                return;
            }

            if (mode == 1 && !(bool)Cache_CheckBox.IsChecked)
            {
                ls.Show();
                Close();
                ls.LaunchWithRyujinxConfig();
                return;
            }

            if ((bool)Cache_CheckBox.IsChecked)
            {
                if (GlumSakCache.CacheExists())
                {
                    ls.ignoreCache = false;
                    ls.Show();
                    Close();
                    ls.LaunchWithLastSesionCache();
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show("No cache found, make sure you started GlumSak without using cache once!\n" +
                                    "Also the cache will always be your last session meaning: " +
                                    "If you launch in Yuzu mode but your last config was created in Ryujinx mode, " +
                                    "it will use the ryujinx config then!",
                                    "Info",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            else if (!DoesEmuBaseDirExist())
            {
                System.Windows.MessageBox.Show("Could not detect default emulator settings directory. " +
                    "If you haven't launched your emulator yet then do so." +
                    "\nIf you have a portable install then go to the settings menu and enter the location.\n\n",
                    "Info",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private bool DoesEmuBaseDirExist()
        {
            if (_mode == 0)
            {
                return Directory.Exists(Yuzu.DefaultBaseLoc);
            }
            return _mode == 1 && Directory.Exists(Ryujinx.DefaultBaseLoc);
        }
    }
}