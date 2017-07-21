using System;
using System.Linq;

namespace MinimumEditDistance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var firstWord = Console.ReadLine();
            var secontWord = Console.ReadLine();

            var table = new int[firstWord.Length + 1, secontWord.Length + 1];
            for (int i = 1; i < table.GetLength(0); i++)
            {
                table[i, 0] = i;
            }

            for (int i = 1; i < table.GetLength(1); i++)
            {
                table[0, i] = i;
            }

            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    if (firstWord[i - 1] == secontWord[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1];
                    }
                    else
                    {
                        table[i, j] = new[] { table[i - 1, j], table[i, j - 1], table[i - 1, j - 1] }.Min() + 1;
                    }
                }
            }

            const double ReplacingCost = 1;
            const double DeletingCost = 0.9;
            const double InsertingCost = 0.8;

            double cost = 0;
            var row = table.GetLength(0) - 1;
            var col = table.GetLength(1) - 1;
            while (row != 0 || col != 0)
            {
                if (row != 0 && col != 0 && table[row - 1, col - 1] == table[row, col])
                {
                    row--;
                    col--;
                }
                else if (col != 0 && table[row, col - 1] + 1 == table[row, col])
                {
                    col--;
                    cost += InsertingCost;
                }
                else if (row != 0 && table[row - 1, col] + 1 == table[row, col])
                {
                    row--;
                    cost += DeletingCost;
                }
                else
                {
                    row--;
                    col--;
                    cost += ReplacingCost;
                }
            }

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(cost);
        }
    }
}
