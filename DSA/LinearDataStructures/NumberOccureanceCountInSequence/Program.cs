using System;
using System.Linq;

namespace NumberOccureanceCountInSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .GroupBy(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} -> {x.Count()} times"));            
        }
    }
}
