using Bunifu.UI.WinForms;
using EmuSak_Revive.Emulators;
using Glumboi.UI;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Drawing;
using Telerik.WinControls.UI.Barcode.Symbology;

namespace EmuSak_Revive.GUI
{
    public partial class SaveManagerWindow : Form
    {
        private string _gameID = string.Empty;

        private List<string> yuzuUserIds = new List<string>();
        private List<string> ryuUserIds = new List<string>();

        private List<string> yuzuUserSavePaths = new List<string>();
        private List<string> ryuUserSavePaths = new List<string>();

        public SaveManagerWindow(string gameID)
        {
            InitializeComponent();
            _gameID = gameID;

            this.Text += $"{gameID}";
        }

        private void SaveManagerWindow_Load(object sender, EventArgs e)
        {
            UIChanger.ChangeTitlebarToDark(Handle);
            LoadAllSaves();
            LoadComboBoxes();
        }

        private void LoadAllSaves()
        {
            LoadRyuSaves();
            LoadYuzuSaves();
        }

        private void LoadRyuSaves()
        {
            var savePath = Ryujinx.GetSavePath(_gameID);

            try
            {
                foreach (var folder in Directory.GetDirectories(savePath))
                {
                    var userId = folder.Split('\\').Last();
                    RyuSavesPath_ListBox.Items.Add($"(User {userId}) {folder}");
                    ryuUserIds.Add(userId);
                    ryuUserSavePaths.Add(folder);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void LoadYuzuSaves()
        {
            Yuzu.GetUserCount(); //Can be used to get the amount of users found, here its only used to initialize the users
            List<string> list = Yuzu.GetGameSavePaths(_gameID);
            for (int i = 0; i < list.Count; i++)
            {
                string item = list[i];
                YuzuSavesPath_ListBox.Items.Add($"(User {i}) {item}");
                yuzuUserIds.Add(i.ToString());
                yuzuUserSavePaths.Add(item);
            }
        }

        private void LoadComboBoxes()
        {
            MoveTo_ComboBox.SelectedIndex = MainWindow.EmuConfig == 0 ? 1 : 0;
            MoveFrom_ComboBox.SelectedIndex = MainWindow.EmuConfig;
        }

        private void OpenSaveLoc_Button_Click(object sender, EventArgs e)
        {
            OpenPathFromDropDown(FromUserName_DropDown, MoveFrom_ComboBox.SelectedIndex);
        }

        private void OpenSaveLocTo_Button_Click(object sender, EventArgs e)
        {
            OpenPathFromDropDown(ToUserName_DropDown, MoveTo_ComboBox.SelectedIndex);
        }

        private void OpenPathFromDropDown(Guna2ComboBox dpd, int emuMode)
        {
            int item = dpd.SelectedIndex;

            if (emuMode == 0)
            {
                OpenPathInExplorer(ryuUserSavePaths[item]);
                return;
            }

            OpenPathInExplorer(yuzuUserSavePaths[item]);
        }

        private void OpenPathInExplorer(string path)
        {
            Process.Start(path);
        }

        private void Expand()
        {
            //1045; 490
            while (this.Width <= 1045)
            {
                this.Width += 5;
                Application.DoEvents();
            }

            ExpandShrink_Button.Image = Properties.Resources.Arrow_Left_Asset;
        }

        private void Shrink()
        {
            //505; 490
            while (this.Width >= 505)
            {
                this.Width -= 5;
                Application.DoEvents();
            }

            ExpandShrink_Button.Image = Properties.Resources.Arrow_Right_Asset;
        }

        private bool IsExpanded()
        {
            return this.Width > 505 ? true : false;
        }

        private void ExpandShrink_Button_Click(object sender, EventArgs e)
        {
            if (!IsExpanded())
            {
                Expand();
            }
            else
            {
                Shrink();
            }
        }

        private void MoveTo_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MoveTo_ComboBox.SelectedIndex == 0)
            {
                UpdateDropDownUsers(ToUserName_DropDown, ryuUserIds);
                return;
            }

            UpdateDropDownUsers(ToUserName_DropDown, yuzuUserIds);
        }

        private void MoveFrom_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MoveFrom_ComboBox.SelectedIndex == 0)
            {
                UpdateDropDownUsers(FromUserName_DropDown, ryuUserIds);
                return;
            }

            UpdateDropDownUsers(FromUserName_DropDown, yuzuUserIds);
        }

        private void UpdateDropDownUsers(Guna2ComboBox dpd, List<string> userIds)
        {
            int oldIndex = dpd.SelectedIndex;

            dpd.Items.Clear();

            foreach (string id in userIds)
            {
                dpd.Items.Add(id);
            }

            dpd.SelectedIndex = oldIndex;
        }

        private void YuzuSavesPath_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenPathInExplorer(yuzuUserSavePaths[YuzuSavesPath_ListBox.SelectedIndex]);
        }

        private void RyuSavesPath_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenPathInExplorer(ryuUserSavePaths[RyuSavesPath_ListBox.SelectedIndex]);
        }

        private void MoveSaves_Button_Click(object sender, EventArgs e)
        {
            StartMovingSaves(
                MoveFrom_ComboBox.SelectedIndex,
                FromUserName_DropDown.SelectedIndex,
                FromUserName_DropDown.SelectedIndex);
        }

        private void StartMovingSaves(int mode, int fromUserDropIndex, int toUserDopIndex)
        {
            string fromPath = string.Empty;
            string targetPath = string.Empty;

            if (mode == 0)
            {
                fromPath = ryuUserSavePaths[fromUserDropIndex];
                targetPath = yuzuUserSavePaths[toUserDopIndex];
            }
            else
            {
                fromPath = yuzuUserSavePaths[fromUserDropIndex];
                targetPath = ryuUserSavePaths[toUserDopIndex];
            }

            CopyAllContentToPath(fromPath, targetPath);
        }

        private void BackupSave(string pathToBackup)
        {
            if (!Directory.Exists("./SaveBackups"))
            {
                Directory.CreateDirectory("./SaveBackups");
            }

            if (!Directory.Exists($"./SaveBackups/{_gameID}"))
            {
                Directory.CreateDirectory($"./SaveBackups/{_gameID}");
            }

            var allFiles = Directory.GetFiles(pathToBackup, "*.*", SearchOption.AllDirectories);

            foreach (string newPath in allFiles)
            {
                File.Copy(newPath, $"./SaveBackups/{_gameID}/{newPath.Split('\\').Last()}", true);
            }
        }

        private void CopyAllContentToPath(string fromPath, string toPath)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that you want to continue?" +
                "\nThis action CAN break your saves as of right now, replaces are not revertable within the app! " +
                "To revert to the old save, you need to go into the SaveBackups folder which sits in the root directory of GlumSak.\n" +
                "A reinstall of the app will delete the backups!\n" +
                "Only saves that got replaced aka the save you moved the other one will get backed up!",
                "WARNING",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            try
            {
                BackupSave(toPath);
            }
            catch (Exception)
            {
            }

            var allFiles = Directory.GetFiles(fromPath, "*.*", SearchOption.AllDirectories);
            foreach (string path in allFiles)
            {
                var newPath = path.Replace(fromPath, toPath);
                File.Copy(path, newPath, true);

                MessageBox.Show($"Successfully replaced save {toPath} with {fromPath}.\n",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}