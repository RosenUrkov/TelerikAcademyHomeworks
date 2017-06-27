using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintVariations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int combinationLenght = int.Parse(Console.ReadLine());
            var set = Console.ReadLine().Split(' ').ToArray();

            GetVariations(combinationLenght, set, new List<string>());
        }

        private static void GetVariations(int combinationLength, string[] set, List<string> variations)
        {
            if (variations.Count == combinationLength)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                GetVariations(combinationLength, set, new List<string>(variations) { set[i] });
            }
        }
    }
}
