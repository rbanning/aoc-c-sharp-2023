using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    internal static class Adventure
    {
        public static readonly string Directory = Path.Combine("Adventures", "data");

        public static string BuildFileName(byte day, AdventureSection section, AdventureSource source)
        {
            return string.Concat("data-", day.ToString().PadLeft(2,'0'), "-", section, source == AdventureSource.sample ? "-sample" : "", ".txt");
        }

        public static string BuildFilePath(byte day, AdventureSection section, AdventureSource source)
        {
            return System.IO.Path.Combine(FileHelper.CurrentDirectory(), Directory, BuildFileName(day, section, source));
        }

    }
}
