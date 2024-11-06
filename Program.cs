using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using SevenZip;
using _7zTool.Compression;
using _7zTool.Extraction;
using _7zTool.Information;
using _7zTool.UI;
using _7zTool.Utilities;

namespace _7zTool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize library path based on architecture
            LibraryPathManager.SetLibraryPath();

            if (args.Length > 0)
            {
                // CLI Mode
                await CommandLineHandler.ExecuteCommand(args);
            }
            else
            {
                // Menu Mode
                await Menu.Display();
            }
        }
    }
}
