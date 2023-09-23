using System.Runtime.InteropServices;
using System.Text.Json;

namespace GlumSak3AV.Switch;

public class Emulator
{
    public string EmulatorName { get; set; }
    public string EmulatorRoot { get; set; }
    public string GamesRootPath { get; set; }
    public List<SwitchGame> Games { get; set; }
    public EmuJsonDummy JsonData { get; set; }

    public Emulator(string jsonPath)
    {
        JsonData = JsonSerializer.Deserialize<EmuJsonDummy>(File.ReadAllText(jsonPath));
        EmulatorName = JsonData.name;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            EmulatorRoot = Environment.ExpandEnvironmentVariables(JsonData.windowsRootPath);
        }
        else
        {
            EmulatorRoot = JsonData.linuxRootPath;
        }

        GamesRootPath = EmulatorRoot + JsonData.gamePath;

        try
        {
            GetGames();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void GetGames()
    {
        if (!JsonData.isGamesCachedAsFolder)
        {
            string[] files = Directory.GetFiles(GamesRootPath);
            for (int i = 0; i < files.Length; i++)
            {
                var span = files[i].AsSpan();
                var start = span.LastIndexOf('\\') + 1;
                var length = span.IndexOf('.') - start;
                string id = span.Slice(start, length).ToString();
                
                Games.Add(new SwitchGame(GamesRootPath, id, ""));
            }
        }
    }

    public void InstallShader()
    {
    }
}