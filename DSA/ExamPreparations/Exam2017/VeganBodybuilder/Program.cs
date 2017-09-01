using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    class Product
    {
        public Product(string name, int weight, int cost)
        {
            this.name = name;
            this.weight = weight;
            this.cost = cost;
        }

        public string name { get; set; }

        public int weight { get; set; }

        public int cost { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int knapsackCapacity = int.Parse(Console.ReadLine()) + 1;
            var prodsCount = int.Parse(Console.ReadLine()) + 1;

            var products = new Product[prodsCount];
            products[0] = new Product("default", 0, 0);

            for (int i = 1; i < prodsCount; i++)
            {
                var prod = Console.ReadLine().Split(' ');
                products[i] = new Product(prod[0], int.Parse(prod[1]), int.Parse(prod[2]));
            }

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
                        table[i, j] = Math.Max(
                                        table[i - 1, j],
                                        table[i - 1, j - products[i].weight] + products[i].cost);
                    }
                }
            }

            int k = table.GetLength(1) - 1;
            var result = new List<string>();

            for (int i = table.GetLength(0) - 1; i > 0; i--)
            {
                if (table[i, k] == table[i - 1, k])
                {
                    continue;
                }

                result.Add(products[i].name);
                k -= products[i].weight;
            }

            Console.WriteLine(table[products.Length - 1, knapsackCapacity - 1]);
            Console.WriteLine(string.Join("\n", result));
        }
    }
}