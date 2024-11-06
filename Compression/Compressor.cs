using SevenZip;
using System;
using System.IO;
using System.Threading.Tasks;

namespace _7zTool.Compression
{
    public static class Compressor
    {
        public static void CompressFile(string inputFile, string outputArchive, CompressionLevel level = CompressionLevel.Normal)
        {
            try
            {
                var compressor = new SevenZipCompressor
                {
                    CompressionLevel = level
                };
                compressor.CompressFiles(outputArchive, inputFile);
                Console.WriteLine($"File compressed to {outputArchive} with {level} compression level.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error compressing file: {ex.Message}");
            }
        }

        public static async Task CompressFileAsync(string inputFile, string outputArchive, CompressionLevel level = CompressionLevel.Normal)
        {
            try
            {
                var compressor = new SevenZipCompressor
                {
                    CompressionLevel = level
                };
                await compressor.CompressFilesAsync(outputArchive, inputFile);
                Console.WriteLine($"File compressed to {outputArchive} with {level} compression level.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error compressing file asynchronously: {ex.Message}");
            }
        }

        public static void CompressDirectory(string inputDirectory, string outputArchive, CompressionLevel level = CompressionLevel.Normal)
        {
            try
            {
                if (!Directory.Exists(inputDirectory))
                {
                    Console.WriteLine($"Directory not found: {inputDirectory}");
                    return;
                }

                var compressor = new SevenZipCompressor
                {
                    CompressionLevel = level
                };
                compressor.CompressDirectory(inputDirectory, outputArchive);
                Console.WriteLine($"Directory compressed to {outputArchive} with {level} compression level.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error compressing directory: {ex.Message}");
            }
        }

        public static async Task CompressDirectoryAsync(string inputDirectory, string outputArchive, CompressionLevel level = CompressionLevel.Normal)
        {
            try
            {
                if (!Directory.Exists(inputDirectory))
                {
                    Console.WriteLine($"Directory not found: {inputDirectory}");
                    return;
                }

                var compressor = new SevenZipCompressor
                {
                    CompressionLevel = level
                };
                await compressor.CompressDirectoryAsync(inputDirectory, outputArchive);
                Console.WriteLine($"Directory compressed to {outputArchive} with {level} compression level.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error compressing directory asynchronously: {ex.Message}");
            }
        }
    }
}
