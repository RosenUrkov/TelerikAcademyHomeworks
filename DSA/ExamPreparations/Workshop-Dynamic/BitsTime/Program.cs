using System;
using System.Linq;

namespace MinimumEditDistance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startBits = Console.ReadLine();
            var endBits = Console.ReadLine();

            const double ChangingCost = 1;
            const double DeletingZeroCost = 0.9;
            const double AddingZeroCost = 1.1;
            const double DeletingOneCost = 0.8;
            const double AddingOneCost = 1.2;

            var table = new double[startBits.Length + 1, endBits.Length + 1];

            for (int i = 1; i < table.GetLength(0); i++)
            {
                table[i, 0] = table[i - 1, 0] + (startBits[i - 1] == '0' ? DeletingZeroCost : DeletingOneCost);
            }
            for (int i = 1; i < table.GetLength(1); i++)
            {
                table[0, i] = table[0, i - 1] + (endBits[i - 1] == '0' ? AddingZeroCost : AddingOneCost);
            }

            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    if (startBits[i - 1] == endBits[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1];
                    }
                    else
                    {
                        var minimal = new[] { table[i - 1, j], table[i, j - 1], table[i - 1, j - 1] }.Min();
                        if (table[i - 1, j] == minimal)
                        {
                            table[i, j] = table[i - 1, j] + (startBits[i - 1] == '0' ? DeletingZeroCost : DeletingOneCost);
                        }
                        if (table[i - 1, j - 1] == minimal)
                        {
                            table[i, j] = table[i - 1, j - 1] + ChangingCost;
                        }
                        else if (table[i, j - 1] == minimal)
                        {
                            table[i, j] = table[i, j - 1] + (endBits[j - 1] == '0' ? AddingZeroCost : AddingOneCost);
                        }
                    }
                }
            }

            Console.WriteLine(table[startBits.Length, endBits.Length]);

            //for (int i = 0; i < table.GetLength(0); i++)
            //{
            //    for (int j = 0; j < table.GetLength(1); j++)
            //    {
            //        Console.Write(table[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
