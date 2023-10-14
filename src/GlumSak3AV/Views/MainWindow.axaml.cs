using Avalonia.Controls;
using GlumSak3AV.Settings;

namespace GlumSak3AV.Views;

public partial class MainWindow : Window
{
    public static MainWindow _currentMainWindow;

    //Used as "entry point" to the app
    public MainWindow()
    {
        InitializeComponent();
        _currentMainWindow = this;
    }
}