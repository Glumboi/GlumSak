using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmuSak_Revive.GUI_WPF.Filtering
{
    internal class Buttons
    {
        public static IEnumerable<Visibility> GetButtonsToHide(IEnumerable<System.Windows.Controls.Button> buttons, string filterSrc)
        {
            foreach (var button in buttons)
            {
                string gameName = button.Tag.GetType().GetProperty("GameName").GetValue(button.Tag, null).ToString();
                if (!gameName.ToLower().Contains(filterSrc.ToLower()))
                {
                    yield return Visibility.Collapsed;
                }
                else
                {
                    yield return Visibility.Visible;
                }
            }
        }
    }
}