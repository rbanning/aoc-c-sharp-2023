namespace AdventOfCode2023
{
    internal static class Input
    {
        public static bool? GetBool(string prompt, string? defaultValue = null, Boolean repeatUntilSuccess = true)
        {
            var done = false;
            bool? result = null;
            var yes = new List<string>() { "y", "yes", "true", "ok" };
            var no = new List<string>() { "n", "no", "false", "never" };

            while (!done)
            {
                Output.Prompt(prompt);
                var input = Console.ReadLine();

                input = (string.IsNullOrEmpty(input)) ? defaultValue : input;

                if (!string.IsNullOrEmpty(input))
                {
                    input = input.Trim().ToLower();

                    if (yes.Contains(input))
                    {
                        result = true;
                        done = true;
                    }
                    else if (no.Contains(input))
                    {
                        result = false;
                        done = true;
                    }
                }

                if (!done)
                {
                    Output.Error("Invalid value - expecting yes/no, true/false");
                    done = !repeatUntilSuccess;
                }
            }

            return result;
        }

        public static int? GetInt(string prompt, Boolean repeatUntilSuccess = true)
        {
            var done = false;
            int? result = null;

            while (!done)
            {
                Output.Prompt(prompt);
                var input = Console.ReadLine();

                if (int.TryParse(input, out var x))
                {
                    result = x;
                    done = true;
                } 
                else
                {
                    Output.Error("Invalid value - expecting an integer");
                    done = !repeatUntilSuccess;
                }
            }

            return result;
        }
        public static byte? GetByte(string prompt, Boolean repeatUntilSuccess = true)
        {
            var done = false;
            byte? result = null;

            while (!done)
            {
                Output.Prompt(prompt);
                var input = Console.ReadLine();

                if (byte.TryParse(input, out var x))
                {
                    result = x;
                    done = true;
                } 
                else
                {
                    Output.Error("Invalid value - expecting a byte (small integer)");
                    done = !repeatUntilSuccess;
                }
            }

            return result;
        }

        public static T? GetEnum<T>(string prompt, Boolean repeatUntilSuccess = true) where T : Enum
        {
            var done = false;
            T? result = default(T);

            var names = Enum.GetNames(typeof(T));

            while (!done)
            {
                Output.Prompt(prompt);
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && Enum.IsDefined(typeof(T), input))
                {
                    result = (T)Enum.Parse(typeof(T), input);
                    done = true;
                }
                else
                {
                    Output.Error($"Invalid value - expecting one of ({string.Join(", ", names)})");
                    done = !repeatUntilSuccess;
                }
            }

            return result;
        }

    }
}
