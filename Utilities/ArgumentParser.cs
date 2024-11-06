namespace _7zTool.Utilities
{
    public static class ArgumentParser
    {
        public static string? GetArgument(string[] args, string key)
        {
            foreach (var arg in args)
            {
                if (arg.StartsWith($"--{key}="))
                {
                    return arg.Split('=')[1];
                }
            }
            return null;
        }
    }
}
