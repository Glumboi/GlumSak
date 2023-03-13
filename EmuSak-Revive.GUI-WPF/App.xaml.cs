using EmuSak_Revive.ConfigIni.Core;
using EmuSak_Revive.GUI_WPF.ExtraWindows;
using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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
        private static App application = new App();

        [STAThread]
        private static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler);

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

        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            //What happens when an exception was raised
            Exception e = (Exception)args.ExceptionObject;
            //MessageBox.Show("MyHandler caught : " + e.Message + "\n" + "Runtime terminating: " + args.IsTerminating);

            ExceptionTranslater el = new ExceptionTranslater(e);
            System.Threading.Thread t = new System.Threading.Thread(el.Translate);
            t.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            t.Start();
        }
    }

    internal class ExceptionTranslater
    {
        private Exception _ex;

        public ExceptionTranslater(Exception ex)
        {
            _ex = ex;
        }

        public void Translate()
        {
            //Launch crash reporter
            var process = new Process
            {
                StartInfo =
              {
                  FileName = "EmuSak-Revive.CrashReporter.exe",
                  Arguments = $"\"\nGlumSak Version {Assembly.GetExecutingAssembly().GetName().Version} Crashed:\n\nShort version: {TranslateShort()}\n\nDetailed Error: {TranslateLong()}\""
              }
            };
            process.Start();
        }

        public string TranslateLong()
        {
            return _ex.ToString(); //Will display en-US message
        }

        public string TranslateShort()
        {
            return _ex.Message.ToString(); //Will display en-US message
        }
    }
}