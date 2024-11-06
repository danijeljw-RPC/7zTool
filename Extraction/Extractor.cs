using SevenZip;
using System;
using System.IO;
using System.Threading.Tasks;

namespace _7zTool.Extraction
{
    public static class Extractor
    {
        public static void ExtractArchive(string archivePath, string outputDirectory)
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
                    extractor.ExtractArchive(outputDirectory);
                    Console.WriteLine($"Archive extracted to {outputDirectory}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting archive: {ex.Message}");
            }
        }

        public static async Task ExtractArchiveAsync(string archivePath, string outputDirectory)
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
                    await extractor.ExtractArchiveAsync(outputDirectory);
                    Console.WriteLine($"Archive extracted to {outputDirectory}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting archive asynchronously: {ex.Message}");
            }
        }
    }
}
