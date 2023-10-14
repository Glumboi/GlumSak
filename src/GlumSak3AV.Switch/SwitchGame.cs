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

    public long LocalShaderCount { get; private set; }

    public long WebShaderCount { get; private set; }

    public Entry PasteDatabaseEntry { get; set; }

    private Bitmap _localImage;


    public Bitmap GameImage
    {
        get
        {
            if (_localImage == null)
            {
                return Networking.WebImage.DownloadImage(ImageURL);
            }

            return _localImage;
        }
    }

    public SwitchGame(string gameName, string gameID, string emulatorShaderRoot, string iamgeURL,
        Entry pasteDatabaseEntry, Bitmap? localImage =
            null)

    {
        GameName = gameName;
        GameID = gameID;
        ImageURL = iamgeURL;
        _localImage = localImage;
        PasteDatabaseEntry = pasteDatabaseEntry;

        //Setup shader path
        GameShaderPath = emulatorShaderRoot.Replace("%GAMEID%", gameID);
        SupportsShaderDownload = GameShaderPath.Contains(gameID);
        if (!Directory.Exists(GameShaderPath)) Directory.CreateDirectory(GameShaderPath);
        LocalShaderCount = GetLocalShaderCount();
        WebShaderCount = GetWebShaderCount();
    }

    private long GetLocalShaderCount()
    {
        string tocFile = $"{GameShaderPath}/shared.toc";

        if (!File.Exists(tocFile)) return 0;

        FileInfo fileInfo = new FileInfo(tocFile);
        return Math.Max(+((fileInfo.Length - 32) / 8), 0);
    }

    private long GetWebShaderCount()
    {
        return 0;
    }
}