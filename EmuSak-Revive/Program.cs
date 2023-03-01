using EmuSak_Revive.GUI;
using System;
using System.Windows.Forms;
using darknet.forms;
using System.Reflection;
using EmuSak_Revive.GUI.Generics;
using EmuSak_Revive.ConfigIni.Core;
using System.IO;

namespace EmuSak_Revive
{
    public static class Program
    {
        private static IniParser iniParser = new IniParser("./updaterConfig.ini");

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DarkNet.SetDarkModeAllowedForProcess(true);

            if (File.Exists(iniParser.GetSetting("config", "exePath")))
            {
                File.Delete(iniParser.GetSetting("config", "exePath"));
            }

            bool isUpdateAvailable = Network.VersionControl.CheckGitHubNewerVersion(Assembly.GetExecutingAssembly()).Result;
            if (isUpdateAvailable && GetSettings.GetCheckForUpdates())
            {
                UpdateWindow updateWindow = new UpdateWindow();
                updateWindow.CurrentVersion_Label.Text = Network.VersionControl.InstalledVersion.ToString();
                updateWindow.NewVersion_Label.Text = Network.VersionControl.NewVersion.ToString();

                try
                {
                    Application.Run(updateWindow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error updating GlumSak!\nDetaield error: " + ex,
                        "Fatal error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            Application.Run(new ConfigurationWindow());
        }
    }
}