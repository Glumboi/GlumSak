using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace EmuSak_Revive.Emulators
{
    public class SwitchGame
    {
        /// <summary>
        /// Gets the Name of the SwitchGame
        /// </summary>
        public string GameName { get; private set; }

        /// <summary>
        /// Gets the ID of the SwitchGame
        /// </summary>
        public string GameID { get; private set; }

        /// <summary>
        /// Gets the URL of the image from the SwitchGame
        /// </summary>
        public string ImageURL { get; private set; }

        /// <summary>
        /// Loads and returns the game image from the web of localimage is null
        /// If localimage is assigned to a System.Drawing.Image then it will return that.
        /// </summary>
        public System.Drawing.Image GameImage
        {
            get
            {
                if (_localImage == null)
                {
                    return Network.Networking.LoadImageFromUrl(_imageUrl, 150, 150);
                }

                return _localImage;
            }
        }

        /// <summary>
        /// Converts the GameImage property to a ImageSource and returns it
        /// </summary>
        public ImageSource GameImageSource
        {
            get
            {
                if (_localImage == null)
                {
                    return ImageEXT.ConvertToImageSource(GameImage);
                }

                return ImageEXT.ConvertToImageSource(_localImage);
            }
        }

        private string _imageUrl;
        private System.Drawing.Image _localImage;

        /// <summary>
        /// Creates a switch game to be interacted with in the UI
        /// </summary>
        /// <param name="gameName">Name of the game</param>
        /// <param name="gameID">ID of the game (not nsuid)</param>
        /// <param name="iamgeURL">Url of the cover image</param>
        /// <param name="localImage">Local image as cover, leave null/default if using url</param>
        public SwitchGame(string gameName, string gameID, string iamgeURL, System.Drawing.Image localImage = null)
        {
            GameName = gameName;
            GameID = gameID;
            ImageURL = iamgeURL;
            _localImage = localImage;
        }
    }

    internal static class ImageEXT
    {
        public static ImageSource ConvertToImageSource(System.Drawing.Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}