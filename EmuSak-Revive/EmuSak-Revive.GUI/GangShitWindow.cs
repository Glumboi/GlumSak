using EmuSak_Revive.GUI.Generics;
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
    public partial class GangShitWindow : Form
    {
        public GangShitWindow()
        {
            InitializeComponent();
        }

        private void GangShitWindow_Load(object sender, EventArgs e)
        {
            UI.ChangeToDarkMode(this);
        }

        private void GangShitWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }
    }
}
