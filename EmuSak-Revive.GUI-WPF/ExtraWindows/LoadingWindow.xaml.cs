using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI_WPF.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties;

namespace EmuSak_Revive.GUI_WPF.ExtraWindows
{
    public partial class LoadingWindow : UiWindow
    {
        private readonly MainWindow mainWindow = new MainWindow();
        public bool ignoreCache = true;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public LoadingWindow()
        {
            InitializeComponent();
        }

        public void LaunchWithLastSesionCache()
        {
            mainWindow.LoadWithCache();
        }

        public void LaunchWithYuzuConfig()
        {
            mainWindow.LoadPortableEmus();
            Yuzu.GetGames();
            mainWindow.ChangeEmuConfig(0);
        }

        public void LaunchWithRyujinxConfig()
        {
            mainWindow.LoadPortableEmus();
            Ryujinx.GetGames();
            mainWindow.ChangeEmuConfig(1);
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (ignoreCache)
            {
                mainWindow.LoadButtons();
            }
            mainWindow.Width = Settings.Default.LastWidth;
            mainWindow.Height = Settings.Default.LastHeight;

            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!mainWindow.DoneLoading) return;
            this.Hide();
            mainWindow.Show();
            dispatcherTimer.Stop();
        }

        private void UiWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}