using System.Threading.Tasks;
using FluentAvalonia.UI.Controls;

namespace GlumSak3AV.CustomBehaviours;

public class GlumSakDialog
{
    private ContentDialog _dlg;

    public GlumSakDialog(
        string title,
        string content,
        string primaryText,
        string secondaryText)
    {
        _dlg = new ContentDialog()
        {
            Title = title,
            Content = content,
            PrimaryButtonText = primaryText,
            CloseButtonText = secondaryText
        };
    }

    public async Task<ContentDialogResult> ShowAsync()
    {
        return await _dlg.ShowAsync();
    }
}