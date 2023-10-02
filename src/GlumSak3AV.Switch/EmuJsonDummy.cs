using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GlumSak3AV.Switch;

public class EmuJsonDummy
{
    public string name { get; set; }
    public string windowsRootPath { get; set; }
    public string linuxRootPath { get; set; }
    public string gamePath { get; set; }
    public string firmwarePath { get; set; }
    public string keysPath { get; set; }
    public bool isGamesCachedAsFolder { get; set; }
}

public static class JsonOperations
{
    public static void WriteNewConfig(EmuJsonDummy json, string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            fileName = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
        }

        var finalFileName = fileName.Contains("EmulatorConfigurations")
            ? fileName
            : $"./EmulatorConfigurations/{fileName}.json";
        File.WriteAllText(finalFileName, JsonSerializer.Serialize(json));
    }
}