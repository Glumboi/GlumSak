using Android.App;
using Android.Content.PM;
using Avalonia.Android;

namespace GlumSak3AV.Android;
[Activity(Label = "GlumSak3AV.Android", Theme = "@style/MyTheme.NoActionBar", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
public class MainActivity : AvaloniaMainActivity
{
}
