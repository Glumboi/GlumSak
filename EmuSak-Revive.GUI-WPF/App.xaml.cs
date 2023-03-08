using EmuSak_Revive.ConfigIni.Core;
using EmuSak_Revive.GUI_WPF.ExtraWindows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace EmuSak_Revive.GUI_WPF
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private static IniParser iniParser = new IniParser("./updaterConfig.ini");

        [STAThread]
        private static void Main()
        {
            App application = new App();

            if (File.Exists(iniParser.GetSetting("config", "exePath")))
            {
                File.Delete(iniParser.GetSetting("config", "exePath"));
            }

            bool isUpdateAvailable = Network.VersionControl.CheckGitHubNewerVersion(Assembly.GetExecutingAssembly()).Result;
            if (isUpdateAvailable && Extensions.GetSettingsProperty.GetAutoUpdate())
            {
                AutoUpdateWindow autoUpdateWindow = new AutoUpdateWindow();

                autoUpdateWindow.AvailableVersion_TextBlock.Text = Network.VersionControl.NewVersion.ToString();
                autoUpdateWindow.CurrentVersion_TextBlock.Text = Network.VersionControl.InstalledVersion.ToString();

                application.InitializeComponent();
                application.Run(autoUpdateWindow);
            }
            else
            {
                application.InitializeComponent();
                application.Run(new ConfigurationWindow());
            }
        }
    }
}