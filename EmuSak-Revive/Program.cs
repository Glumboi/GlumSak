using EmuSak_Revive.GUI;
using System;
using System.Windows.Forms;
using Glumboi.Debug;

namespace EmuSak_Revive
{
    public static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfigurationWindow());
        }
    }
}
