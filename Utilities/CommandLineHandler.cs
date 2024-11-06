using _7zTool.Compression;
using _7zTool.Extraction;
using _7zTool.Information;
using SevenZip;
using System;
using System.Threading.Tasks;

namespace _7zTool.Utilities
{
    public static class CommandLineHandler
    {
        public static async Task ExecuteCommand(string[] args)
        {
            // Check for help arguments
            if (args.Length == 0 || args[0].Equals("/h", StringComparison.OrdinalIgnoreCase) ||
                args[0].Equals("/help", StringComparison.OrdinalIgnoreCase) ||
                args[0].Equals("-h", StringComparison.OrdinalIgnoreCase) ||
                args[0].Equals("--help", StringComparison.OrdinalIgnoreCase) ||
                args[0].Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(HelpFile.HelpText);
                return;
            }

            try
            {
                string command = args[0].ToLower();

                switch (command)
                {
                    case "compress":
                        string compressType = ArgumentParser.GetArgument(args, "type") ?? throw new ArgumentException("Compress type is required.");
                        string inputPath = ArgumentParser.GetArgument(args, "input") ?? throw new ArgumentException("Input path is required.");
                        string outputArchive = ArgumentParser.GetArgument(args, "output") ?? throw new ArgumentException("Output archive path is required.");
                        string levelArg = ArgumentParser.GetArgument(args, "level") ?? "Normal";

                        if (!Enum.TryParse(levelArg, true, out CompressionLevel level))
                        {
                            Console.WriteLine("Invalid compression level. Using 'Normal' by default.");
                            level = CompressionLevel.Normal;
                        }

                        if (compressType == "file")
                        {
                            await Compressor.CompressFileAsync(inputPath, outputArchive, level);
                        }
                        else if (compressType == "directory")
                        {
                            await Compressor.CompressDirectoryAsync(inputPath, outputArchive, level);
                        }
                        else
                        {
                            Console.WriteLine("Invalid compression type. Use 'file' or 'directory'.");
                        }
                        break;

                    case "extract":
                        string archivePath = ArgumentParser.GetArgument(args, "archive") ?? throw new ArgumentException("Archive path is required.");
                        string outputDir = ArgumentParser.GetArgument(args, "output") ?? throw new ArgumentException("Output directory is required.");
                        await Extractor.ExtractArchiveAsync(archivePath, outputDir);
                        break;

                    case "info":
                        string infoPath = ArgumentParser.GetArgument(args, "archive") ?? throw new ArgumentException("Archive path is required.");
                        ArchiveInfo.DisplayInfo(infoPath);
                        break;

                    default:
                        Console.WriteLine("Unknown command. Use /h, /help, -h, --help, or help for assistance.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing command: {ex.Message}");
            }
        }
    }
}
