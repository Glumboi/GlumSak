using System.Diagnostics;
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
    public string ShaderCacheRootPath { get; set; }
    public List<SwitchGame>? Games { get; set; } = new List<SwitchGame>();
    public EmuJsonDummy JsonData { get; set; }
    public string JsonFile { get; set; }
    public string EmulatorPaste { get; set; }
    public IniReader? IniDatabase { get; set; }

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
            shaderCacheRootpath = "Shader cache root path",
            isGamesCachedAsFolder = false,
            keysPath = "Keys path",
            gamePath = "Games path",
            emulatorPaste = ""
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
        ShaderCacheRootPath = !JsonData.supportsShaderInstallation ? "UNDEFINED" : EmulatorRoot + JsonData.shaderCacheRootpath;
        EmulatorPaste = JsonData.emulatorPaste;

        LoadPaste();
    }

    private void LoadPaste()
    {
        if (!string.IsNullOrWhiteSpace(EmulatorPaste))
        {
            IniDatabase = new IniReader(EmulatorPaste);
        }
    }

    public List<SwitchGame>? GetGames()
    {
        LoadPaste();
        
        Games.Clear();

        try
        {
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

                    var game = StaticInstances.NintendoEShopApi.GetGameFromDatabaseByID(id);
                    if (game != null)
                        Games.Add(new SwitchGame(game.name, game.id, this.ShaderCacheRootPath, game.iconUrl,
                            IniDatabase?.GetValue("ShaderCount", game.id, "N/A") ?? "N/A",
                            IniDatabase?.GetValue("ShaderURL", game.id, string.Empty) ?? string.Empty));
                }

                return Games;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
            return null;
        }

        return new List<SwitchGame>();
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