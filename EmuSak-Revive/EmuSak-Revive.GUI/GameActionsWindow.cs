using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.Network;
using Glumboi.UI;
using Glumboi.UI.Toast;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmuSak_Revive.GUI
{
    public partial class GameActionsWindow : Form
    {
        public string GameName { get; private set; }
        public string GameID { get; private set; }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private static bool shaderExists = false;//!string.IsNullOrEmpty(dlUrl);
        private static string shaderUrl = string.Empty;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public GameActionsWindow()
        {
            InitializeComponent();
        }

        public void Init(Image img, string gameName, string gameId)
        {
            Game_PrictureBox.Image = img;
            GameName = gameName;
            GameID = gameId;
            GameId_Label.Text = GameID;
            shaderUrl = Networking.GetShaderDownload(GameName);
        }

        private void CheckShader()
        {
            shaderExists = !string.IsNullOrWhiteSpace(shaderUrl);
        }

        private void GameActionsWindow_Load(object sender, EventArgs e)
        {
            Game_PrictureBox.BorderRadius = 0;
            UIChanger.ChangeTitlebarToDark(Handle);
            CheckShader();
            if (!shaderExists)
            {
                bunifuLabel1.Text = "No shader available for this game!";
                var originalLoc = bunifuLabel1.Location;
                var newLoc = new Point(originalLoc.X - bunifuLabel1.Text.Length, originalLoc.Y);
                bunifuLabel1.Location = newLoc;
            }
        }

        private void GameActionsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        private void DownloadShaders_Button_Click(object sender, EventArgs e)
        {
            DownloadShader(GameName, GameID);
        }

        public static void DownloadShader(string gameName, string gameId)
        {
            shaderUrl = Networking.GetShaderDownload(gameName);
            shaderExists = !string.IsNullOrWhiteSpace(shaderUrl);

            if (shaderExists)
            {
                EmuShader.InstallShader(New.MainWindow.EmuConfig, Networking.GetShaderDownload(gameName), gameId);
                return;
            }
            ToastHandler.ShowToast($"There is no shader available for {gameName} at the moment.", "Info");
        }

        private void SaveManager_Button_Click(object sender, EventArgs e)
        {
            SaveManagerWindow saveManagerWindow = new SaveManagerWindow(GameID);
            saveManagerWindow.Show();
        }
    }
}