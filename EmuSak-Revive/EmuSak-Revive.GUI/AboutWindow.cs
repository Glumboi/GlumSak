using EmuSak_Revive.GUI.Generics;
using EmuSak_Revive.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuSak_Revive.GUI
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            UI.ChangeToDarkMode(this);
            LangLoader.Run();
        }

        private void Github_Button_Click(object sender, EventArgs e)
        {
            Networking.LaunchURLInBrowser("https://github.com/Glumboi");
        }

        private void EmuSakUI_Button_Click(object sender, EventArgs e)
        {
            Networking.LaunchURLInBrowser("https://github.com/CapitaineJSparrow/emusak-ui");
        }

        private void AboutWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        private void bunifuSeparator2_Click(object sender, EventArgs e)
        {
        }

        private void Text_Label_Click(object sender, EventArgs e)
        {
        }

        private void About_Label_Click(object sender, EventArgs e)
        {
        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {
        }
    }
}