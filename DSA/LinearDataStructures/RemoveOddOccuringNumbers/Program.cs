using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOccuringNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();

            Console.ReadLine()
             .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .GroupBy(x => x)
             .Where(x => x.Count() % 2 == 0)
             .ToList()
             .ForEach(x => list.AddRange(x));

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
