namespace AdventOfCode2023
{
    internal static class Output
    {
        public static byte Width = 120;

        public static void Reset()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Header(string text)
        {
            text = Center(text);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Join("",Enumerable.Repeat("-", Width).ToArray()));
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join("", Enumerable.Repeat("-", Width).ToArray()));

            Reset();
        }

        public static void Write(string text)
        {
            Console.Write(text);
        }
        public static void WriteLine(string text = "")
        {
            text = string.IsNullOrEmpty(text) ? " " : text;
            Console.WriteLine(text);
        }


        public static void WriteResult(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Result: ");
            Reset();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" " + text);
            Reset();
        }

        public static void Prompt(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Reset();
            Console.Write(" > ");
        }

        public static void Warn(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Warning...");
            Reset();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  " + text);
            Reset();
        }

        public static void Error(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Error...");
            Reset();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  " + text);
            Reset();
        }

        static string Center(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Join("", Enumerable.Repeat(' ', Width).ToArray());
            }
            //else
            var padding = string.Join("", Enumerable.Repeat(' ', (Width - text.Length) / 2));
            return string.Concat(padding, text, padding).PadRight(Width);
        }
    }
}
