using Avalonia.Media.Imaging;

namespace GlumSak3AV.Switch;

public class SwitchGame
{
    /// <summary>
    /// Gets the Name of the SwitchGame
    /// </summary>
    public string GameName
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the ID of the SwitchGame
    /// </summary>
    public string GameID
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the URL of the image from the SwitchGame
    /// </summary>
    public string ImageURL
    {
        get;
        private set;
    }

    /// <summary>
    /// Loads and returns the game image from the web of localimage is null
    /// If localimage is assigned to a System.Drawing.Image then it will return that.
    /// </summary>
    private Bitmap _localImage;

    public Bitmap GameImage
    {
        get
        {
            if (_localImage == null)
            {
                return Networking.WebImage.DownloadImage(ImageURL);
               // Network.Networking.LoadImageFromUrl(ImageURL, 150, 150);
            }

            return _localImage;
        }
    }

    private string _imageUrl;

    /// <summary>
    /// Creates a switch game to be interacted with in the UI
    /// </summary>
    /// <param name="gameName">Name of the game</param>
    /// <param name="gameID">ID of the game (not nsuid)</param>
    /// <param name="iamgeURL">Url of the cover image</param>
    /// <param name="localImage">Local image as cover, leave null/default if using url</param>
    public SwitchGame(string gameName, string gameID, string iamgeURL, Bitmap localImage =
        null)

    {
        GameName = gameName;
        GameID = gameID;
        ImageURL = iamgeURL;
        _localImage = localImage;
    }
}