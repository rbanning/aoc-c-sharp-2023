namespace AdventOfCode2023
{
    class Program
    {
        static void Main(string[] args)
        {
            Output.Header("Advent of Code ... 2023");
            if (args.Length == 0)
            {
                RunAdventure();
            }
            else
            {
                switch (args[0])
                {
                    case "--init":
                        RunInit();
                        break;
                    default:
                        Output.Error("Invalid command argument: " + args[0]);
                        break;
                }
            }
        }

        static void RunAdventure()
        {
            var done = false;
            while (!done)
            {
                try
                {
                    var day = Input.GetByte("Which day would you like to run?");
                    var section = Input.GetEnum<AdventureSection>("Which section (a,b)?");
                    var source = Input.GetBool("Use the sample data (Y/n)?", "y") == true
                            ? AdventureSource.sample : AdventureSource.real;
                    var verbose = Input.GetBool("Verbose (y/N)? ", "n") == true;

                    if (day.HasValue)
                    {
                        Output.WriteLine($"We are going with #{(day)}-{(section)}");

                        var adventure = AdventureRepo.Find(day.Value, section);
                        if (adventure != null)
                        {
                            Output.WriteLine($"Using data file: {adventure.FileName(source)}");
                            var result = adventure.Run(source, verbose == true);
                            Output.WriteResult(result.ToString());
                        }
                        else
                        {
                            Output.Warn($"Sorry, adventure {day}{section} is not available");
                        }

                        Output.WriteLine("");
                        done = Input.GetBool("Try another (Y/n)?", "y") != true;
                    }
                }
                catch (AdventureException ex)
                {
                    Output.Error($"Failed to run adventure: {ex.Message}");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        static void RunInit()
        {
            Output.WriteLine("Initializing data files...");

            var results = InitializeData.CreateFilesForTheseDays(1, 25);

            foreach (var item in results)
            {
                var success = item.Value.Count(m => m == InitializeData.ResultEnum.success);
                var error = item.Value.Count(m => m == InitializeData.ResultEnum.error);
                var skipped = item.Value.Count(m => m == InitializeData.ResultEnum.skipped);

                string day = item.Key.ToString().PadLeft(2, '0');
                var text = $"Day #{day}: {success} files created, {(skipped == 0 ? "none" : skipped.ToString())} skipped.";
                if (error > 0)
                {
                    text += $" {error} error(s) encountered";
                    Output.Warn(text);
                }
                else
                {
                    Output.WriteLine(text);
                }
            }
        }
    }
}