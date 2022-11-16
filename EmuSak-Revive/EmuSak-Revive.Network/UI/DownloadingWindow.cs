using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Glumboi.UI;

namespace EmuSak_Revive.Network.UI
{
    public partial class DownloadingWindow : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public string LoadingText{ get; set; }

        public DownloadingWindow()
        {
            InitializeComponent();
        }

        public void StartLoadingAnimations()
        {
            //Animates the label
            string[] stringsForAnimation = {
                "Busy downloading",
                "Busy downloading.",
                "Busy downloading..",
                "Busy downloading..."
            };

            AnimateText textAnimator = new AnimateText(bunifuLabel1, stringsForAnimation, 300);
            textAnimator.Run();
            radWaitingBar1.StartWaiting();
        }

        private void DownloadingWindow_Load(object sender, EventArgs e)
        {
            UIChanger.ChangeTitlebarToDark(Handle);
            bunifuLabel1.Text = LoadingText;
        }

        private void DownloadingWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
