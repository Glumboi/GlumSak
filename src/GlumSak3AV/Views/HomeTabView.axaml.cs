using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GlumSak3AV.CustomControls;
using GlumSak3AV.Switch;
using GlumSak3AV.ViewModels;

namespace GlumSak3AV.Views;

public partial class HomeTabView : UserControl
{
    public HomeTabView()
    {
        InitializeComponent();

        this.DataContext = new HomeTabViewModel();
    }
}