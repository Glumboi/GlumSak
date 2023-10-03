using System.IO.Compression;

namespace GlumSak3AV.Files;

public static class Zip
{
    public static void Unzip(
        string inputFile,
        string outPath,
        bool deleteAfterDone = true,
        bool filesInFolder = false,
        string childFolderName = "")
    {
        using (ZipArchive source = ZipFile.Open(inputFile, ZipArchiveMode.Read, null))
        {
            foreach (ZipArchiveEntry entry in source.Entries)
            {
                string fullPath = Path.GetFullPath(Path.Combine(outPath, entry.FullName));

                if (Path.GetFileName(fullPath).Length != 0)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                    entry.ExtractToFile(fullPath, true);
                }
            }
        }

        if (filesInFolder)
        {
            CopyExtensions.CopyFilesRecursively(childFolderName, outPath);

            Directory.Delete(childFolderName, true);
        }

        if (deleteAfterDone)
        {
            File.Delete(inputFile);
        }
    }
}