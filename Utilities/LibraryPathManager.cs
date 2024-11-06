using SevenZip;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace _7zTool.Utilities
{
    public static class LibraryPathManager
    {
        public static void SetLibraryPath()
        {
            try
            {
                var architecture = RuntimeInformation.ProcessArchitecture;
                string libraryPath = Path.Combine(AppContext.BaseDirectory, architecture == Architecture.X64 ? "x64" : "x86", "7z.dll");
                
                if (!File.Exists(libraryPath))
                {
                    throw new FileNotFoundException($"7z.dll not found in path: {libraryPath}");
                }
                
                SevenZipBase.SetLibraryPath(libraryPath);
                Console.WriteLine($"7z library loaded from: {libraryPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting library path: {ex.Message}");
            }
        }
    }
}
