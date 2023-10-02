using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace GlumSak3AV.Networking;

public class Downloader
{
    private WebClient _webClient;
    private Stopwatch _stopWatch;

    private string _currentTempFile;


    public Downloader()
    {
        _webClient = new WebClient();
        _stopWatch = new Stopwatch();

        _webClient.DownloadProgressChanged += UpdateProgress;
        _webClient.DownloadFileCompleted += DownloadDone;
    }

    ~Downloader()
    {
        DownloadDone(_webClient, new AsyncCompletedEventArgs(null, true, null));
        _webClient.DownloadProgressChanged -= UpdateProgress;
        _webClient.DownloadFileCompleted -= DownloadDone;
        _webClient.Dispose();
    }

    public void DownloadFile(string addr, string tempPath, string unzipPath)
    {
        _currentTempFile = $"{tempPath}/GlumSakTemp_{new Random().Next(0, Int32.MaxValue)}.tempSakFile";
        _webClient.DownloadFileTaskAsync(addr, _currentTempFile);
        _stopWatch.Start();
    }

    private void UpdateProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        double bytesIn = double.Parse(e.BytesReceived.ToString());
        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        double percentage = bytesIn / totalBytes * 100;
        int percentageString = int.Parse(Math.Truncate(percentage).ToString());

        // Calculate progress values
        double fileSize = totalBytes / 1024.0 / 1024.0;
        double downloadSpeed = e.BytesReceived / 1024.0 / 1024.0 / _stopWatch.Elapsed.TotalSeconds;

        //Calculate ETA
        double remainingBytes = totalBytes - bytesIn;
        double remainingTime = remainingBytes / (downloadSpeed * 1024 * 1024);
        string remainingTimeString = TimeSpan.FromSeconds(remainingTime).ToString(@"hh\:mm\:ss");

        string progressBarText = string.Format("{0} MB/s | {1}: {2} MB | ETA: {3}",
            downloadSpeed.ToString("0.00"),
            "File Size",
            GetFileSizeWithoutComma(fileSize),
            remainingTimeString);

        Console.Write($"\r{progressBarText}");
    }

    private void DownloadDone(object? sender, AsyncCompletedEventArgs e)
    {
        Console.WriteLine($"Done downloading: {e.Error}");
        File.Delete(_currentTempFile);
        _stopWatch.Reset();
    }

    private string GetFileSizeWithoutComma(double totalBytes)
    {
        if (totalBytes.ToString().Contains(","))
        {
            return totalBytes.ToString().Split(',')[0];
        }

        return totalBytes.ToString().Split('.')[0];
    }
}