using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuSak_Revive.GUI.Generics
{
    internal class UI
    {
        public static void ChangeToDarkMode(Form frm)
        {
            Glumboi.UI.UIChanger.ChangeTitlebarToDark(frm.Handle);
            frm.BackColor = Color.FromArgb(40, 40, 40);
        }
    }
}
