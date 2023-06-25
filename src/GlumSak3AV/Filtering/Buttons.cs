using System.Collections.Generic;
using Avalonia.Controls;
using GlumSak3AV.CustomControls;

namespace GlumSak3AV.Filtering;

public class Buttons
{
    public static void GetButtonsToHide(ref List<GameButton> buttons, string filterSrc)
    {
        foreach (var button in buttons)
        {
            string gameName = button.GameName;
            if (!gameName.ToLower().Contains(filterSrc.ToLower()))
            {
                button.IsVisible = false;
            }
            else
            {
                button.IsVisible = true;
            }
        }
    }
}