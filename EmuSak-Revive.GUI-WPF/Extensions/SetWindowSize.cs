using System.Windows;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.GUI_WPF.Extensions
{
    internal class SetWindowSize
    {
        public static void ChangeLastSizeOfMainWindow(UiWindow uiWindow)
        {
            //Height="625"
            //             ->Window default Height and Width
            //Width = "900"
            if (uiWindow.WindowState == WindowState.Maximized)
            {
                Properties.Settings.Default.LastWidth = 900;
                Properties.Settings.Default.LastHeight = 625;
                return;
            }

            Properties.Settings.Default.LastWidth = (int)uiWindow.Width;
            Properties.Settings.Default.LastHeight = (int)uiWindow.Height;
        }
    }
}