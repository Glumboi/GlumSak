using Avalonia.Controls;

namespace GlumSak3AV.Views;

public partial class MainWindow : Window
{
    public static MainWindow _currentMainWindow;

    public MainWindow()
    {
        InitializeComponent();

        _currentMainWindow = this;
    }
}