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
            //return ParseLineAdvancedAlt(line);

            var first = ParseLineAdvancedSingle(line, false);
            var last = ParseLineAdvancedSingle(line, true);

            return (first.HasValue && last.HasValue) ? (first.Value * 10 + last.Value) : -1;

        }

        private List<string> _digitLookup = new List<string>() { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private int? ParseLineAdvancedSingle(string line, bool reverse)
        {
            int? value = null;

            var index = reverse ? line.Length - 1 : 0;
            var delta = reverse ? -1 : 1;

            while (!value.HasValue && index >= 0 && index < line.Length)
            {
                var current = line.Substring(index);

                if (int.TryParse(current[0].ToString(), out int v))
                {
                    value = v;
                }
                else
                {
                    //check for spelled out digit
                    for (var i = 0; i < _digitLookup.Count && !value.HasValue; i++)
                    {
                        if (current.StartsWith(_digitLookup[i]))
                        {
                            value = i;
                        }
                    }
                }

                index += delta;
            }

            return value;
        }

        private int ParseLineAdvancedAlt(string line)
        {
            int? first = null;
            int? last = null;
            for (int i = 0; i < line.Length; i++)
            {
                var current = line.Substring(i);
                char c = current[0];
                if (int.TryParse(c.ToString(), out var result))
                {
                    if (!first.HasValue) { first = result; }
                    last = result;
                } 
                else
                {
                    var digit = _digitLookup.FirstOrDefault(m => current.StartsWith(m));
                    if (digit != null)
                    {
                        var value = _digitLookup.IndexOf(digit);
                        if (!first.HasValue) { first = value; }
                        last = value;
                    }
                }
            }

            return (first.HasValue && last.HasValue) ? (first.Value * 10 + last.Value) : -1;
        }


        #endregion

    }
}
