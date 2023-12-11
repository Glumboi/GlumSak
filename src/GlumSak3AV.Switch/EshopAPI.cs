using System.Collections.Concurrent;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Avalonia.Platform;
using GlumSak3AV.Settings;
using Newtonsoft.Json;
using SkiaSharp;

namespace GlumSak3AV.Switch;

public class NintendoEShopAPI
{
    public string DataBaseURL { get; set; }

    private const string jsonDir = "./Json";
    private const string nsuIDFile = jsonDir + "/nsuIds.txt";
    private const string databseFile = jsonDir + "/gameIcons_Ids.txt";

    public NintendoEShopAPI()
    {
        DataBaseURL = SettingsFactory.Settings.Value.switchGameDatabaseCrawl;

        if (!Directory.Exists(jsonDir)) Directory.CreateDirectory(jsonDir);
        if (!File.Exists(nsuIDFile)) File.Create(nsuIDFile).Close();
        if (!File.Exists(databseFile)) File.Create(databseFile).Close();
        SetupGameMeta();
    }

    public void SetupGameMeta()
    {
        CreateNsuIDsFile(DataBaseURL);
        DonwloadGameMeta();
    }

    private void CreateNsuIDsFile(string URL)
    {
        using (FileStream fs = new FileStream(nsuIDFile, FileMode.OpenOrCreate))
        using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
        {
            foreach (var item in GetNsuIds(URL))
            {
                sw.WriteLine(item);
            }
        }
    }

    private IEnumerable<string> GetNsuIds(string url)
    {
        const string pattern = @"nsuId"": (\d+)";
        var regex = new Regex(pattern);
  
        using (var client = new WebClient())
        using (var stream = client.OpenRead(url))
        using (var reader = new StreamReader(stream))
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null) break;

                var match = regex.Match(line);
                if (match.Success)
                {
                    yield return match.Groups[1].Value;
                }
            }
        }
    }

    private void DonwloadGameMeta()
    {
        using (HttpClient client = new HttpClient())
        {
            //nsuIds = File.ReadLines(nsuIDFile).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            GetAll(JsonConvert.DeserializeObject<Dictionary<string, GameData>>(client.GetStringAsync(DataBaseURL).Result));
        }
    }

    private static void GetAll(Dictionary<string, GameData>? data)
    {
        ConcurrentQueue<string> lines = new ConcurrentQueue<string>();

        Parallel.ForEach(File.ReadLines(nsuIDFile), fileLine =>
        {
            if (data.ContainsKey(fileLine))
            {
                GameData gameData = data[fileLine];
                string line = JsonConvert.SerializeObject(gameData.iconUrl, Newtonsoft.Json.Formatting.Indented) +
                              " | " +
                              JsonConvert.SerializeObject(gameData.id, Newtonsoft.Json.Formatting.Indented) + " | " +
                              JsonConvert.SerializeObject(gameData.name, Newtonsoft.Json.Formatting.Indented);
                lines.Enqueue(line);
            }
        });

        File.WriteAllText(databseFile, string.Join(Environment.NewLine, lines));
    }

    public GameData? GetGameFromDatabaseByID(string gameId)
    {
        if (!File.Exists(databseFile))
        {
            SetupGameMeta();
        }

        var lines = File.ReadLines(databseFile);

        foreach (string line in lines)
        {
            if (line.Contains(gameId, StringComparison.OrdinalIgnoreCase))
            {
                var span = line.AsSpan();
                int start = 0;
                string[] parts = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    int end = span.Slice(start).IndexOf('|');
                    if (end == -1) end = span.Length - start; // For the last part
                    ReadOnlySpan<char> part = span.Slice(start, end).Trim().Trim('\"'); // Remove spaces and quotes
                    start += end + 1; // Move to the next part
                    parts[i] = part.ToString(); // Store the string value
                }

                string url = parts[0];
                string id = parts[1];
                string title = parts[2];

                return new GameData
                {
                    iconUrl = url,
                    id = id,
                    name = title
                };
            }
        }

        return null;
    }
}

public class GameData
{
    public string iconUrl { get; set; }
    public string id { get; set; }
    public string name { get; set; }
}