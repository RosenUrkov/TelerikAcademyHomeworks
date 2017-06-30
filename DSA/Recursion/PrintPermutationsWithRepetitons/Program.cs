using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintPermutationsWithRepetitons
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var set = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var permutations = new List<string>();
            GetParmutationsWithRepetitons(set, "", permutations);
            permutations.ForEach(Console.WriteLine);
        }

        private static void GetParmutationsWithRepetitons(int[] set, string permutation, List<string> permutations)
        {
            if (permutation.Length == set.Length)
            {
                if (!permutations.Any(x => x == permutation))
                {
                    permutations.Add(permutation);
                }

                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                if (permutation.Count(x => (x - '0') == set[i]) < set.Count(x => x == set[i]))
                {
                    GetParmutationsWithRepetitons(set, permutation + set[i], permutations);
                }
            }
        }
    }
}
