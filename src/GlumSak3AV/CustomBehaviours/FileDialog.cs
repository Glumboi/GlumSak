using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace GlumSak3AV.CustomBehaviours;

public class FileDialog
{
    public static void OpenFileLocation(string path)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"/select, \"{Path.GetFullPath(path) }\"",
                UseShellExecute = true
            });
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "open",
                Arguments = $"-R \"{path}\"",
                UseShellExecute = true
            });
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "xdg-open",
                Arguments = $"\"{System.IO.Path.GetDirectoryName(path)}\"",
                UseShellExecute = true
            });
        }
    }
}