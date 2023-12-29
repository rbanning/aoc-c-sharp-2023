using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    internal static class InitializeData
    {
        public enum ResultEnum
        {
            success,
            error,
            skipped
        }
        public static ResultEnum[] CreateFilesSingleDay(byte day)
        {

            var files = new List<string>()
            {
                Adventure.BuildFilePath(day, AdventureSection.a, AdventureSource.sample),
                Adventure.BuildFilePath(day, AdventureSection.a, AdventureSource.real),
                Adventure.BuildFilePath(day, AdventureSection.b, AdventureSource.sample),
                Adventure.BuildFilePath(day, AdventureSection.b, AdventureSource.real),
            };

            ResultEnum[] results = new ResultEnum[files.Count];
            
            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    results[i] = (FileHelper.CreateEmptyFile(files[i]))
                        ? ResultEnum.success
                        : ResultEnum.skipped;
                }
                catch (Exception)
                {
                    results[i] = ResultEnum.error;
                }
            }
            
            return results;
        }

        public static Dictionary<byte, ResultEnum[]> CreateFilesForTheseDays(byte startDay, byte lastDay)
        {
            var results = new Dictionary<byte, ResultEnum[]>();

            for (byte day = startDay;  day <= lastDay; day++)
            {
                results.Add(day, CreateFilesSingleDay(day));
            }

            return results;
        }
    }
}
