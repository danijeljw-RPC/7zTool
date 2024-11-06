using SevenZip;
using System;
using System.IO;

namespace _7zTool.Information
{
    public static class ArchiveInfo
    {
        public static void DisplayInfo(string archivePath)
        {
            try
            {
                if (!File.Exists(archivePath))
                {
                    Console.WriteLine($"Archive file not found: {archivePath}");
                    return;
                }

                using (var extractor = new SevenZipExtractor(archivePath))
                {
                    Console.WriteLine($"Archive: {archivePath}");
                    Console.WriteLine($"Files: {extractor.FilesCount}");

                    foreach (var file in extractor.ArchiveFileData)
                    {
                        Console.WriteLine($" - {file.FileName}, Size: {file.Size}, Compressed: {file.PackedSize}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying archive info: {ex.Message}");
            }
        }
    }
}
