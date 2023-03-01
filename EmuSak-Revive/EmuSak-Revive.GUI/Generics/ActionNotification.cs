using Infragistics.Win.UltraColorPalette;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuSak_Revive.GUI.Generics
{
    public class ActionNotification
    {
        public Type ActionType { get; set; }
        public Color ActionColor { get => GetActionColor(); }

        public enum Type
        {
            NONE = 0,
            SUCCESS = 1,
            WARNING = 2,
            ERROR = 3
        }

        public ActionNotification(Type actionType)
        {
            this.ActionType = actionType;
        }

        private Color GetActionColor()
        {
            switch (ActionType)
            {
                case Type.NONE:
                    return Color.Gray;

                case Type.SUCCESS:
                    return Color.Green;

                case Type.WARNING:
                    return Color.Yellow;

                case Type.ERROR:
                    return Color.Red;
            }

            return Color.White;
        }

        public void ShowMessageBox(string content, string title, MessageBoxButtons btns)
        {
            MessageBoxIcon msgIcon = new MessageBoxIcon();

            switch (ActionType)
            {
                case Type.NONE:
                    msgIcon = MessageBoxIcon.Question;
                    break;

                case Type.SUCCESS:
                    msgIcon = MessageBoxIcon.Information;
                    break;

                case Type.WARNING:
                    msgIcon = MessageBoxIcon.Warning;
                    break;

                case Type.ERROR:
                    msgIcon = MessageBoxIcon.Error;
                    break;
            }

            MessageBox.Show(title, content, btns, msgIcon);
        }

        public void ShowNotification(Form frm, Point location, int height = 16, int width = 16)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Properties.Resources.Ryujinx_Asset;
            pictureBox.Location = location;
            pictureBox.Size = new Size(width, height);
            pictureBox.Show();
        }
    }
}