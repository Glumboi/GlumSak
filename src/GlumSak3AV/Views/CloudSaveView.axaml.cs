using Avalonia.Controls;
using GlumSak3AV.ViewModels;

namespace GlumSak3AV.Views;

public partial class CloudSaveView : UserControl
{
    public CloudSaveView()
    {
        InitializeComponent();

        this.DataContext = new CloudSaveViewModel();
    }
}