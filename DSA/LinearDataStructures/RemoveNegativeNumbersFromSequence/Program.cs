using System;
using System.Linq;

namespace RemoveNegativeNumbersFromSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x >= 0)
                .ToList();

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
