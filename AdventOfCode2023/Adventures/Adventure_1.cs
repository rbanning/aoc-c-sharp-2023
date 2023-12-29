namespace AdventOfCode2023.Adventures
{
    internal class Adventure_1: AdventureBase
    {
        public Adventure_1(AdventureSection section)
            :base(1, section, "First Adventure")
        {}


        public override int Run(AdventureSource source, bool verbose = false)
        {
            try
            {
                var data = LoadData(source);
                if (data == null) { throw new AdventureException("Data was null"); }

                var values = Section == AdventureSection.a
                    ? LineIntsBasic(data, verbose)
                    : LineIntsAdvanced(data, verbose);

                var result = values.Aggregate(0, (ret, curr) => ret + curr);

                return result;

            }
            catch (AdventureException) { throw; }
            catch (Exception ex)
            {
                throw new AdventureException("Error running the adventure", ex);
            }
        }

        #region >>> SECTION A <<<

        private List<int> LineIntsBasic(List<string> data, bool verbose =  false)
        {
            return data.Select(line =>
            {
                var value = ParseLineBasic(line);
                if (verbose)
                {
                    Output.WriteLine($"({value}) from '{line}'");
                }
                return value;
            }).ToList();
        }

        private int ParseLineBasic(string line)
        {
            int? first = null;
            int? last = null;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (int.TryParse(c.ToString(), out var result))
                {
                    if (!first.HasValue) { first = result; }
                    last = result;
                }
            }

            return (first.HasValue && last.HasValue) ? (first.Value * 10 + last.Value) : -1;
        }

        #endregion


        #region >>> SECTION B <<<

        private List<int> LineIntsAdvanced(List<string> data, bool verbose =  false)
        {
            return data.Select(line =>
            {
                var value = ParseLineAdvanced(line);
                if (verbose)
                {
                    Output.WriteLine($"({value}) from '{line}'");
                }
                return value;
            }).ToList();
        }


        private int ParseLineAdvanced(string line)
        {
            int? first = null;
            int? last = null;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (int.TryParse(c.ToString(), out var result))
                {
                    if (!first.HasValue) { first = result; }
                    last = result;
                }
            }

            return (first.HasValue && last.HasValue) ? (first.Value * 10 + last.Value) : -1;
        }

        #endregion

    }
}
