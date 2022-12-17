using EmuSak_Revive.GUI;
using System;
using System.Windows.Forms;
using Glumboi.Debug;
using EmuSak_Revive.GUI.New;

namespace EmuSak_Revive
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfigurationWindow());
        }
    }
}