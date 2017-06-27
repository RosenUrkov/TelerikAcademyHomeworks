using System;
using System.Collections.Generic;

namespace PrintPermutations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            GetPermutations(number, new List<int>());
        }

        private static void GetPermutations(int number, List<int> permutations)
        {
            if (permutations.Count == number)
            {
                Console.WriteLine($"{{{string.Join(", ", permutations)}}}");
                return;
            }

            for (int i = 1; i <= number; i++)
            {
                if (!permutations.Contains(i))
                {
                    GetPermutations(number, new List<int>(permutations) { i });
                }
            }
        }
    }
}
