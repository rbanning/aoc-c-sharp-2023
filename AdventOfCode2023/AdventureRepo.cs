using AdventOfCode2023.Adventures;

namespace AdventOfCode2023
{
    internal static class AdventureRepo
    {
        static Dictionary<byte, Func<byte, AdventureSection, IAdventure>> lookup = new Dictionary<byte, Func<byte, AdventureSection, IAdventure>>();

        static AdventureRepo()
        {
            lookup[1] = (byte day, AdventureSection section) => new Adventure_1(section);
        }


        public static IAdventure? Find(byte day, AdventureSection section)
        {
            if (lookup.ContainsKey(day))
            {
                var fn = lookup[day];
                return fn(day, section);
            }
            //else
            return null;
        }

        
    }
}
