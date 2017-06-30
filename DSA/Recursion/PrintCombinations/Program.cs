using System;
using System.Collections.Generic;

namespace PrintCombinations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var subsetLength = int.Parse(Console.ReadLine());
            var set = Console.ReadLine().Split(' ');

            GetCombinations(0, subsetLength, set, new List<string>());
        }

        private static void GetCombinations(int current, int combinationLength, string[] set, List<string> combinations)
        {
            if (combinations.Count >= combinationLength)
            {
                Console.WriteLine(string.Join(", ", combinations));
                return;
            }

            for (int i = current; i < set.Length; i++)
            {
                GetCombinations(i + 1, combinationLength, set, new List<string>(combinations) { set[i] });
            }
        }
    }
}
