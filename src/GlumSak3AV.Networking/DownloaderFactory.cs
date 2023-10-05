using GlumSak3AV.Networking.CustomControls;

namespace GlumSak3AV.Networking;

public class DownloaderFactory
{
    public static void CreateNewDownloader(out Downloader dl, out CustomProgressBar pb)
    {
        dl = new Downloader();
        pb = dl.DownloadProgressBar;
    }
}