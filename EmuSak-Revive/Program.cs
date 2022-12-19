using EmuSak_Revive.GUI;
using System;
using System.Windows.Forms;
using Glumboi.Debug;
using EmuSak_Revive.GUI.New;
using darknet.forms;

namespace EmuSak_Revive
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DarkNet.SetDarkModeAllowedForProcess(true);
            Application.Run(new ConfigurationWindow());
        }
    }
}