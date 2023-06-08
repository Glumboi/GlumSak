using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI_WPF.Properties;
using System;
using System.Windows;
using System.Windows.Media.Animation;
using Wpf.Ui.Controls;

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

        private void AnimateControls()
        {
            Storyboard s = (Storyboard)TryFindResource("UpdateDots");
            s.Begin();
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AnimateControls();

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