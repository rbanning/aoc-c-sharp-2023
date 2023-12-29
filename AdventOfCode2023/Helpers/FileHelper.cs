namespace AdventOfCode2023.Helpers
{
    internal static class FileHelper
    {

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public static string ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            } 
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Could not locate the file you requested: {path}");
            }

            //else
            return System.IO.File.ReadAllText(path);
        }

        public static bool EnusureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Directory.Exists(path);
        }

        public static string CurrentDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? "";
        }

        public static bool CreateEmptyFile(string path)
        {
            if (File.Exists(path))
            {
                return false;
            }

            var f = File.CreateText(path);
            f.Dispose();
            return true;

        }
    }
}
