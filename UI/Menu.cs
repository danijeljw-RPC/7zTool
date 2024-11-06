using _7zTool.Compression;
using _7zTool.Extraction;
using _7zTool.Information;

namespace _7zTool.UI
{
    public static class Menu
    {
        public static async Task Display()
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Compress a File");
                Console.WriteLine("2. Compress a Directory");
                Console.WriteLine("3. Extract an Archive");
                Console.WriteLine("4. Display Archive Info");
                Console.WriteLine("5. Exit");

                // Assign a clear invalid choice if input is null
                string choice = Console.ReadLine() ?? "InvalidChoice";
                string input = "InvalidPath"; // Default for invalid paths
                string output = "InvalidPath";

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter file path to compress: ");
                        input = Console.ReadLine() ?? "InvalidFilePath";
                        Console.Write("Enter output archive path: ");
                        output = Console.ReadLine() ?? "InvalidOutputPath";
                        await Compressor.CompressFileAsync(input, output);
                        break;

                    case "2":
                        Console.Write("Enter directory path to compress: ");
                        input = Console.ReadLine() ?? "InvalidDirectoryPath";
                        Console.Write("Enter output archive path: ");
                        output = Console.ReadLine() ?? "InvalidOutputPath";
                        await Compressor.CompressDirectoryAsync(input, output);
                        break;

                    case "3":
                        Console.Write("Enter archive path to extract: ");
                        input = Console.ReadLine() ?? "InvalidArchivePath";
                        Console.Write("Enter output directory path: ");
                        output = Console.ReadLine() ?? "InvalidOutputDirectory";
                        await Extractor.ExtractArchiveAsync(input, output);
                        break;

                    case "4":
                        Console.Write("Enter archive path to display info: ");
                        input = Console.ReadLine() ?? "InvalidArchivePath";
                        ArchiveInfo.DisplayInfo(input);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
    }
}
