using System;
using System.Linq;

namespace FindLongestSubsequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .GroupBy(x=> x)
                .OrderByDescending(x => x.Count())
                .First()
                .ToList();

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
