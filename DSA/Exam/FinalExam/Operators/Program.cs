using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster
{
    class Program
    {
        static HashSet<string> results = new HashSet<string>();
        static DataTable dataTable = new DataTable();
        static long target = 0;
        static string input;

        static void Main(string[] args)
        {
            input = Console.ReadLine();
            target = int.Parse(Console.ReadLine());

            Recursion(0, "");

            Console.WriteLine(results.Count);
            Console.WriteLine(string.Join("\n", results));
        }

        static void Recursion(int index, string current)
        {
            if (index >= input.Length)
            {
                current = current.TrimStart('+', '*', '-');
                var currentSum = (int)dataTable.Compute(current, "");

                if (currentSum == target)
                {
                    results.Add(string.Join("", current));
                }

                return;
            }

            for (int i = index; i < input.Length; i++)
            {
                if (input[index] == '0' && i != index)
                {
                    continue;
                }

                var right = input.Substring(index, i - index + 1);

                var expression = current + "+" + right;
                Recursion(i + 1, expression);

                expression = current + "*" + right;
                Recursion(i + 1, expression);

                expression = current + "-" + right;
                Recursion(i + 1, expression);
            }
        }
    }
}
