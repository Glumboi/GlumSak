using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace GlumSak3AV.CustomBehaviours;

public class CurrentApplication
{
    public static void Close()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApp)
        {
            desktopApp.Shutdown();
        }
        else if (Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime viewApp)
        {
            viewApp.MainView = null;
        }
    }
}