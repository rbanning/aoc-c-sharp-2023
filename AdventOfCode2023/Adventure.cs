using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    internal static class Adventure
    {
        public static readonly string Directory = Path.Combine("Adventures", "data");

        static string DayToString(byte day)
        {
            return day.ToString().PadLeft(2, '0');
        }

        public static string BuildFileName(byte day, AdventureSection section, AdventureSource source)
        {
            return string.Concat("data-", DayToString(day), "-", section, source == AdventureSource.sample ? "-sample" : "", ".txt");
        }

        public static string BuildFileDirectory(byte day)
        {
            return System.IO.Path.Combine(FileHelper.CurrentDirectory(), Directory, DayToString(day));
        }
        public static string BuildFilePath(byte day, AdventureSection section, AdventureSource source)
        {
            return System.IO.Path.Combine(BuildFileDirectory(day), BuildFileName(day, section, source));
        }

    }
}
