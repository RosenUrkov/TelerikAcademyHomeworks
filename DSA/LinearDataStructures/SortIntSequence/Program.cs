using System;
using System.Collections.Generic;

namespace SortIntSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                list.Add(int.Parse(input));
            }

            // too lazy
            list.Sort();
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
