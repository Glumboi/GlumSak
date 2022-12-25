using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI.Generics;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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

        private void GetSettings()
        {
            Cache_CheckBox.Checked = Properties.Settings.Default.UseLastSession;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.UseLastSession = Cache_CheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void ConfigureWindow_Load(object sender, EventArgs e)
        {
            UI.ChangeToDarkMode(this);
            GetSettings();
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

        private void LaunchApp(int mode)
        {
            LoadingScreen ls = new LoadingScreen();
            try
            {
                if (mode == 0 && !Cache_CheckBox.Checked)
                {
                    ls.Show();
                    Close();
                    ls.LaunchWithYuzuConfig();
                    return;
                }

                if (mode == 1 && !Cache_CheckBox.Checked)
                {
                    ls.Show();
                    Close();
                    ls.LaunchWithRyujinxConfig();
                    return;
                }

                if (Cache_CheckBox.Checked)
                {
                    if (GlumSakCache.CacheExists())
                    {
                        ls.ignoreCache = false;
                        ls.Show();
                        Close();
                        ls.LaunchWithLastSesionCache();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No cache found, make sure you started GlumSak without using cache once!\n" +
                                "Also the cache will always be your last session meaning: " +
                                "If you launch in Yuzu mode but your last config was created in Ryujinx mode, " +
                                "it will use the ryujinx config then!",
                                "Info",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not detect default emulator settings directory. " +
                    "If you haven't launched your emulator yet then do so." +
                    "\nIf you have a portable install then go to the settings menu and enter the location.\n\n",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

        private void ConfigurationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            SaveSettings();
            Hide();
        }
    }
}