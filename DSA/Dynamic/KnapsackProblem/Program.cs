using System;
using System.Linq;

namespace KnapsackProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var products = new(string name, int weight, int cost)[]
            {
                ("default", 0, 0),

                ("beer", 3, 4),
                ("vodka", 8, 12),
                ("cheese", 4, 5),
                ("ham", 2, 3),
                ("whiskey", 8, 13),
                ("greedy-breaker", 7, 100),
            };

            int knapsackCapacity = 10;

            var table = new int[products.Length, knapsackCapacity];
            for (int i = 1; i < products.Length; i++)
            {
                for (int j = 0; j < knapsackCapacity; j++)
                {
                    if (products[i].weight > j)
                    {
                        table[i, j] = table[i - 1, j];
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i - 1, j],
                                               table[i - 1, j - products[i].weight]
                                                    + products[i].cost);
                    }
                }
            }

            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    Console.Write(table[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();


            var dynamicTable = new int[2, knapsackCapacity];
            for (int i = 1; i < products.Length; i++)
            {
                for (int j = 0; j < knapsackCapacity; j++)
                {
                    if (products[i].weight > j)
                    {
                        dynamicTable[i % 2, j] = dynamicTable[(i - 1) % 2, j];
                    }
                    else
                    {
                        dynamicTable[i % 2, j] = Math.Max(dynamicTable[(i - 1) % 2, j],
                                                          dynamicTable[(i - 1) % 2, j - products[i].weight]
                                                                      + products[i].cost);
                    }
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < knapsackCapacity; col++)
                {
                    Console.Write(dynamicTable[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(dynamicTable[(products.Length - 1) % 2, knapsackCapacity - 1]);
        }
    }
}
