using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace EmuSak_Revive.CrashReporter
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private static App application = new App();

        [STAThread]
        private static void Main(string[] args)
        {
            application.InitializeComponent();
            application.Run(new MainWindow(args));
        }
    }
}