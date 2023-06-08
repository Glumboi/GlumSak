using EmuSak_Revive.GUI_WPF.Extensions;
using EmuSak_Revive.GUI_WPF.PluginExtra;
using EmuSak_Revive.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.GUI_WPF.CustomControls
{
    /// <summary>
    /// Interaction logic for PluginListItem.xaml
    /// </summary>
    public partial class PluginCard : UserControl
    {
        public bool AutoRun
        {
            get { return (bool)GetValue(AutoRunProperty); }
            set { SetValue(AutoRunProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutoRun.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoRunProperty =
            DependencyProperty.Register("AutoRun", typeof(bool), typeof(PluginCard), new PropertyMetadata(false));

        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(PluginCard), new PropertyMetadata(null));

        public string PluginName
        {
            get { return (string)GetValue(PluginNameProperty); }
            set { SetValue(PluginNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PluginName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PluginNameProperty =
            DependencyProperty.Register("PluginName", typeof(string), typeof(PluginCard), new PropertyMetadata(string.Empty));

        private Plugin _plugin;

        public PluginCard(Plugin plugin, bool autoRun)

        {
            InitializeComponent();
            _plugin = plugin;
            if (File.Exists(plugin.PluginIcon))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(plugin.PluginIcon);
                bitmap.EndInit();
                IconSource = bitmap;
            }
            else
            {
                IconSource = null;
            }

            PluginName = plugin.PluginName;
            AutoRun = autoRun;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ChangePluginState(_plugin, true);
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            ChangePluginState(_plugin, false);
        }

        private void ChangePluginState(Plugin plugin, bool state)
        {
            if (state)
            {
                plugin.ExecutePlugin();
                return;
            }

            plugin.StopPlugin();
        }

        private void AutoRun_SwitchUnchecked(object sender, RoutedEventArgs e)
        {
            PluginHelpers.autorunPlugins.Remove(_plugin);
        }

        private void AutoRun_SwitchChecked(object sender, RoutedEventArgs e)
        {
            if (PluginHelpers.autorunPlugins.Contains(_plugin)) return;
            PluginHelpers.autorunPlugins.Add(_plugin);
        }
    }
}