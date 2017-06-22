using System;
using System.Linq;

namespace NumberOccureanceCountInSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var majorant = list
                .GroupBy(x => x)
                .Where(x => x.Count() >= (list.Count / 2 + 1))
                .Select(x => x.Key);

            Console.WriteLine(majorant.Count() == 0 ? "No majorant!" : majorant.First().ToString());
        }
    }
}