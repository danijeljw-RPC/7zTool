# 7zTool

**7zTool** is a C# console application for compressing and extracting files and directories using the `7-Zip` library. This tool provides a menu-driven interface and supports command-line arguments for seamless integration with scripts and automated tasks.

---

## Features

- **File and Directory Compression**: Compress individual files or entire directories into `.7z` format.
- **File Extraction**: Extract contents of `.7z` archives to a specified directory.
- **Archive Information**: Display information about files within an archive, including sizes and compression levels.
- **Compression Levels**: Choose from various compression levels like Ultra, High, Normal, Fast, and Low.
- **Flexible Input Handling**: Handles both file and directory paths, with support for command-line arguments.

---

## Requirements

- .NET SDK (6.0 or later)
- [7z.Libs](https://www.nuget.org/packages/7z.Libs) NuGet package for accessing `7z.dll`
- [SevenZipSharp](https://www.nuget.org/packages/SevenZipSharp) or an equivalent library for .NET integration with `7-Zip`

---

## Setup

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/7zTool.git
    cd 7zTool
    ```

2. Install the required NuGet packages:

    ```bash
    dotnet add package 7z.Libs
    dotnet add package SevenZipSharp-zg
    ```

3. Ensure that `7z.dll` is located in the `x64` or `x86` folder within the output directory, depending on your system architecture.

4. Build the project:

    ```bash
    dotnet build
    ```

5. Run the application:

    ```bash
    dotnet run
    ```

---

## Usage

### Menu-Driven Interface

When you run `7zTool` without arguments, a menu will appear:

```plaintext
Select an option:
1. Compress a File
2. Compress a Directory
3. Extract an Archive
4. Display Archive Info
5. Exit
```

Each option provides prompts to enter file paths and other relevant details.

### Command-Line Interface

You can also run 7zTool with command-line arguments. This allows for scripting and automation.

#### General Syntax

```bash
dotnet run -- {command} [options]
```

#### Commands and Options

1. **Compress a File**

    ```bash
    dotnet run -- compress --type=file --input="path/to/file.txt" --output="output.7z" --level=High
    ```

1. **Compress a Directory**

    ```bash
    dotnet run -- compress --type=directory --input="path/to/directory" --output="output.7z" --level=Ultra
    ```

1. **Extract an Archive**

    ```bash
    dotnet run -- extract --archive="path/to/archive.7z" --output="output_directory"
    ```

1. **Display Archive Info**

    ```bash
    dotnet run -- info --archive="path/to/archive.7z"
    ```

#### Help Command

To display the help menu, run:

```bash
dotnet run -- help
```

Or use any of these options:

- `/h`
- `/help`
- `-h`
- `--help`

### Compression Levels

You can specify the compression level with the `--level` option:

- `None`
- `Fast`
- `Low`
- `Normal` _(default)_
- `High`
- `Ultra`

Example:

```bash
dotnet run -- compress --type=file --input="path/to/file.txt" --output="output.7z" --level=Ultra
```

---

## Code Overview

### Key Classes

- **Compressor:** Handles file and directory compression with options for synchronous and asynchronous operations.
- **Extractor:** Handles extraction of archive contents.
- **ArchiveInfo:** Displays information about files within an archive.
- **CommandLineHandler:** Processes command-line arguments and executes the appropriate action.
- **LibraryPathManager:** Automatically detects and loads the correct `7z.dll` for the system's architecture.
- **ArgumentParser:** Parses named arguments in the command-line interface.

### Error Handling

The application provides user-friendly error messages for common issues, such as invalid paths or missing files. Paths are automatically trimmed of extra quotes for compatibility.

---

## Examples

- **Compress a File:**

    ```bash
    dotnet run -- compress --type=file --input="C:\Files\myfile.txt" --output="C:\Files\myfile.7z" --level=High
    ```

- **Compress a Directory:**

    ```bash
    dotnet run -- compress --type=directory --input="C:\MyFolder" --output="C:\MyFolderArchive.7z" --level=Ultra
    ```

- **Extract an Archive:**

    ```bash
    dotnet run -- extract --archive="C:\Files\myfile.7z" --output="C:\ExtractedFiles"
    ```

- **Display Archive Info:**

    ```bash
    dotnet run -- info --archive="C:\Files\myfile.7z"
    ```

---

## Contributing

Feel free to fork the repository, make improvements, and submit pull requests. Contributions are welcome!

## License

This project is licensed under the [MIT License](LICENSE).
