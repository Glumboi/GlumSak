using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI.Generics;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace EmuSak_Revive.GUI
{
    public partial class ConfigurationWindow : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public ConfigurationWindow()
        {
            InitializeComponent();
        }

        private void ConfigureWindow_Load(object sender, EventArgs e)
        {
            UI.ChangeToDarkMode(this);

            /*BunifuToolTip yuzuToolTip = new BunifuToolTip();
            BunifuToolTip ryujinxToolTip = new BunifuToolTip();

            yuzuToolTip.SetToolTip(Yuzu_Button, "Launches the app in Yuzu mode");
            ryujinxToolTip.SetToolTip(Ryujinx_Button, "Launches the app in Ryujinx mode");*/
        }

        private void ConfigureWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void LaunchApp(int mode)
        {
            LoadingScreen ls = new LoadingScreen();
            if (mode == 0)
            {
                this.Hide(); 
                ls.Show(); 
                ls.LaunchWithYuzuConfig(); 
                return;
            }

            if (mode == 1)
            {
                this.Hide();
                ls.Show();
                ls.LaunchWithRyujinxConfig();
                return;
            }
        }

        private void Ryujinx_Button_Click(object sender, EventArgs e)
        {
            LaunchApp(1);
        }

        private void Yuzu_Button_Click(object sender, EventArgs e)
        {
            LaunchApp(0);
        }
    }
}
