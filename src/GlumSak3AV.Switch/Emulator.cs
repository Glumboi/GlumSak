using System.Runtime.InteropServices;
using System.Text.Json;
using GlumSak3AV.Networking;

namespace GlumSak3AV.Switch;

public class Emulator
{
    public string EmulatorName { get; set; }
    public string EmulatorRoot { get; set; }
    public string GamesRootPath { get; set; }
    public string FirmwareRootPath { get; set; }
    public string KeysRootPath { get; set; }
    public List<SwitchGame> Games { get; set; } = new List<SwitchGame>();
    public EmuJsonDummy JsonData { get; set; }
    public string JsonFile { get; set; }

    private string _tempPath;

    public Emulator()
    {
        _tempPath = Path.GetTempPath();

        JsonData = new EmuJsonDummy
        {
            name = "EmulatorConfig name",
            linuxRootPath = "Linux root path",
            firmwarePath = "Firmware path",
            windowsRootPath = "Windows path",
            isGamesCachedAsFolder = false,
            keysPath = "Keys path",
            gamePath = "Games path"
        };
    }

    public Emulator(string jsonPath)
    {
        _tempPath = Path.GetTempPath();

        JsonData = JsonSerializer.Deserialize<EmuJsonDummy>(File.ReadAllText(jsonPath));
        JsonFile = jsonPath;
        EmulatorName = JsonData.name;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            EmulatorRoot = Environment.ExpandEnvironmentVariables(JsonData.windowsRootPath);
        }
        else
        {
            EmulatorRoot = JsonData.linuxRootPath.Contains("%LINUXUSER%")
                ? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                  JsonData.linuxRootPath.Replace("%LINUXUSER%", String.Empty)
                : JsonData.linuxRootPath;
        }

        GamesRootPath = EmulatorRoot + JsonData.gamePath;
        FirmwareRootPath = EmulatorRoot + JsonData.firmwarePath;
        KeysRootPath = EmulatorRoot + JsonData.keysPath;
    }

    public List<SwitchGame> GetGames()
    {
        Games.Clear();

        if (Directory.Exists(GamesRootPath))
        {
            string[] idSources = JsonData.isGamesCachedAsFolder
                ? Directory.GetDirectories(GamesRootPath)
                : Directory.GetFiles(GamesRootPath);
            for (int i = 0; i < idSources.Length; i++)
            {
                var span = idSources[i].Replace('\\', '/').AsSpan();
                var start = span.LastIndexOf('/') + 1;
                var length = idSources[i].Contains(".pv") ? span.LastIndexOf('.') - 3 - start : span.Length - start;
                string id = span.Slice(start, length).ToString();

                var game = EshopAPI.GetGameFromDatabaseByID(id);
                if (game != null) Games.Add(new SwitchGame(game.name, game.id, game.iconUrl));
            }

            return Games;
        }

        return null;
    }

    public DownloadSettings KeysDownload(string keysUrl)
    {
        return new DownloadSettings(
            false,
            true,
            false,
            keysUrl,
            _tempPath,
            KeysRootPath);
    }

    public DownloadSettings FirmwareDownload(string firmwareUrl)
    {
        return new DownloadSettings(false,
            true,
            false,
            firmwareUrl,
            _tempPath,
            FirmwareRootPath,
            () =>
            {
                if (this.JsonData.isGamesCachedAsFolder)
                {
                    var files = Directory.GetFiles(this.FirmwareRootPath);

                    for (var index = 0; index < files.Length; index++)
                    {
                        var file = files[index].Replace('\\', '/');
                        var splitted = file.Split('/');

                        for (var i = 0; i < splitted.Length; i++)
                        {
                            var fileName = splitted[i];
                            if (fileName.Contains(".nca"))
                            {
                                File.Move(file, this.FirmwareRootPath + "/" + "/00");
                                Directory.CreateDirectory(this.FirmwareRootPath + "/" + fileName);
                                File.Move(this.FirmwareRootPath + "/00",
                                    this.FirmwareRootPath + "/" + fileName + "/00");
                            }
                        }
                    }
                }
            }
        );
    }
}