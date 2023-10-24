using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GlumSak3AV.Networking;

public class HttpClientWrapper
{
    private readonly HttpClient _client;

    public event Action<long, long> ProgressChanged;
    public event Action DownloadCompleted;

    public HttpClientWrapper()
    {
        _client = new HttpClient();
    }

    public async Task DownloadFileAsync(string requestUrl, string filename, CancellationToken cancellationToken)
    {
        try
        {
            using (var response =
                   await _client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength;

                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None,
                           8192, true))
                {
                    var totalRead = 0L;
                    var buffer = new byte[8192];
                    var isMoreToRead = true;

                    do
                    {
                        var read = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            await fileStream.WriteAsync(buffer, 0, read);

                            totalRead += read;
                            ProgressChanged?.Invoke(totalBytes.HasValue ? totalBytes.Value : -1, totalRead);
                        }
                    } while (isMoreToRead);
                }
            }

            DownloadCompleted?.Invoke();
        }
        catch (OperationCanceledException)
        {
            // Wait for the file stream to dispose before deleting the file

            await Task.Delay(1000);
            File.Delete(filename);
            throw;
        }
    }
}