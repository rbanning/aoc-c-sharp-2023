using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    internal abstract class AdventureBase : IAdventure
    {

        public string? Name { get; }
        public byte Day { get; }
        public AdventureSection Section { get; }

        public AdventureBase(byte day, AdventureSection section)
            :this(day, section, null) { }
        public AdventureBase(byte day, AdventureSection section, string? name)
        {
            Day = day;
            Section = section;
            Name = name;
        }


        public virtual int Run(AdventureSource source, bool verbose = false)
        {
            return -1;
        }

        public string FileName(AdventureSource source)
        {
            return Adventure.BuildFileName(Day, Section, source);
        }
        protected string FilePath(AdventureSource source)
        {
            return Adventure.BuildFilePath(Day, Section, source);
        }

        protected List<string> LoadData(AdventureSource source)
        {
            try
            {
                var path = FilePath(source);
                if (!FileHelper.FileExists(path))
                {
                    throw new AdventureException("Could not locate the data file");
                }
                var content = FileHelper.ReadFile(FilePath(source));
                var data = content.Split(Environment.NewLine)
                    .Select(m => m.Trim())
                    .Where(m =>  m.Length > 0)
                    .ToList();
                
                //validate
                if (data.Count == 0) { throw new AdventureException("No data was found in the data file"); }

                return data;
            }
            catch (AdventureException) { throw; }
            catch (Exception ex)
            {
                throw new AdventureException("Error loading the data", ex);
            }
        }



    }
}
