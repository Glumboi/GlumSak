using System.Text.Json;

namespace GlumSak3AV.Settings;

public static class SettingsFactory
{
    public static GlumsakSettings Settings { get; set; }
    
    public static void LoadSettings()
    {
        Settings = JsonSerializer.Deserialize<GlumsakSettings>(File.ReadAllText("GlumSakSettings.json"));
    }
}