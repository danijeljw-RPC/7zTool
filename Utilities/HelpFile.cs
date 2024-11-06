namespace _7zTool.Utilities
{
    public static class HelpFile
    {
        public static string HelpText = @"
7zTool Command-Line Help

Usage:
  dotnet run -- {command} [options]

Commands:
  compress          Compress a file or directory into a 7z archive.
  extract           Extract the contents of a 7z archive to a specified directory.
  info              Display information about the contents of a 7z archive.
  help              Display this help menu.

Options:
  --type            Specifies the type of compression target (required for compress).
                    Use 'file' to compress a single file, or 'directory' to compress a directory.
  --input           The path to the input file or directory for compression.
                    For compress, required with --type. For extract, the archive to extract.
  --output          The path where the archive will be created or extracted.
                    Required for compress and extract commands.
  --archive         The path of the archive file to display info on (required for info).
  --level           Specifies the compression level. Options are None, Fast, Low, Normal, High, Ultra.
                    Default is 'Normal' if unspecified.

Examples:
  Compress a File with High Compression:
    dotnet run -- compress --type=file --input=path/to/file.txt --output=output.7z --level=High

  Compress a Directory with Ultra Compression:
    dotnet run -- compress --type=directory --input=path/to/directory --output=output.7z --level=Ultra

  Extract an Archive:
    dotnet run -- extract --archive=path/to/archive.7z --output=output_directory

  Display Archive Info:
    dotnet run -- info --archive=path/to/archive.7z

Help Options:
  /h, /help, -h, --help, help  Display this help menu.
";
    }
}
