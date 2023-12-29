namespace AdventOfCode2023
{
    internal class AdventureException : Exception
    {
        public AdventureException(): base() { }
        public AdventureException(string message): base(message) { }
        public AdventureException(string message, Exception inner): base(message, inner) { }
    }
}
