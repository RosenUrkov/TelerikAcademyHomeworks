using System;
using System.Collections.Generic;
using System.Linq;

namespace OddPresenceElements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            // easy way
            list
            .GroupBy(x => x)
            .Where(x => x.Count() % 2 == 1)
            .Select(x => x.Key)
            .ToList()
            .ForEach(Console.WriteLine);

            // hard way
            var set = new HashSet<string>();
            list.ForEach(x =>
            {
                if (!set.Add(x))
                {
                    set.Remove(x);
                }
            });

            Console.WriteLine(string.Join(", ", set));
        }
    }
}
