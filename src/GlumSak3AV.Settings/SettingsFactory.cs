using System.Text.Json;

namespace GlumSak3AV.Settings;

public static class SettingsFactory
{
    private const string _defaultSettings = "" +
                                            "{\n  " +
                                            "\"switchGameDatabaseCrawl\": \"https://raw.githubusercontent.com/blawar/titledb/master/US.en.json\"," +
                                            "\n  \"fimwaresCrawl\": \"https://dn802605.us.archive.org/0/items/nintendo-switch-global-firmwares/\"" +
                                            "\n}";

    private const string _settingsPath = "GlumSakSettings.json";

    private static GlumsakSettings? _settings;

    public static GlumsakSettings? Settings
    {
        get
        {
            if (_settings == null)
            {
                LoadSettings();
            }

            return _settings;
        }
        set => _settings = value;
    }

    public static void LoadSettings()
    {
        if (!File.Exists(_settingsPath))
        {
            File.WriteAllText(_settingsPath, _defaultSettings);
        }

        Settings = JsonSerializer.Deserialize<GlumsakSettings>(File.ReadAllText(_settingsPath));
    }
}