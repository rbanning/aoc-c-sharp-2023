namespace AdventOfCode2023
{
    internal enum AdventureSection
    {
        a, b
    }
    internal enum AdventureSource
    {
        sample,
        real
    }
    internal interface IAdventure
    {
        string? Name { get; }
        byte Day { get; }
        AdventureSection Section { get; }

        int Run(AdventureSource source, bool verbose = false);

        string FileName(AdventureSource source);
    }
}
