using System.Net;
using Avalonia.Media.Imaging;

namespace GlumSak3AV.Networking;

public static class WebImage
{
    public static Bitmap DownloadImage(string url)
    {
        using (WebClient client = new WebClient())
        {
            var data = client.DownloadData(new Uri(url));
            Stream stream = new MemoryStream(data);

            return new Bitmap(stream);
        }
    }
}