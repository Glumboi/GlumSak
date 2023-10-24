using Avalonia.Media.Imaging;
using FluentAvalonia.Core;
using GlumSak3AV.Networking;

namespace GlumSak3AV.Switch;

public class SwitchGame
{
    public string GameName { get; private set; }

    public string GameID { get; private set; }

    public string GameShaderPath { get; private set; }

    public bool SupportsShaderDownload { get; private set; }

    public string ImageURL { get; private set; }
    
    private string _shaderDownloadURL;

    public string ShaderDownloadURL
    {
        get => _shaderDownloadURL;
        set => _shaderDownloadURL = value;
    }


    private string _webShaderCount;

    public string WebShaderCount
    {
        get => _webShaderCount;
        set => _webShaderCount = value;
    }

    public string LocalShaderCount { get; private set; }

    private Bitmap _localImage;

    public SwitchGame(string gameName, string gameID, string emulatorShaderRoot, string iamgeURL,
        string webShaderCount, string shaderDownloadUrl, Bitmap? localImage =
            null)

    {
        GameName = gameName;
        GameID = gameID;
        ImageURL = iamgeURL;
        _localImage = localImage;
        
        //Setup shader path
        GameShaderPath = emulatorShaderRoot.Replace("%GAMEID%", gameID);
        SupportsShaderDownload = GameShaderPath.Contains(gameID);
        LocalShaderCount = GetLocalShaderCount().ToString();
        ShaderDownloadURL = shaderDownloadUrl;
        WebShaderCount = webShaderCount;

        if (!Directory.Exists(GameShaderPath)) Directory.CreateDirectory(GameShaderPath);
    }

    private long GetLocalShaderCount()
    {
        string tocFile = $"{GameShaderPath}/shared.toc";

        if (!File.Exists(tocFile)) return 0;

        FileInfo fileInfo = new FileInfo(tocFile);
        return Math.Max(+((fileInfo.Length - 32) / 8), 0);
    }
}