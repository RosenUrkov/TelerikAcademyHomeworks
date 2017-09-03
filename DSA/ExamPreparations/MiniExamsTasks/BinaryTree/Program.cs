using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static HashSet<BigInteger> generaged = new HashSet<BigInteger>();
        static int[] result;

        static BigInteger[] numbers;
        static BigInteger maxNumber;
        static int n = 0;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            numbers = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            maxNumber = numbers.Max();

            result = new int[numbers.Length];
            generaged.Add(1);
            DFS(1);

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 1)
                {
                    result[i] = 0;
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static void DFS(BigInteger current)
        {
            if (current >= maxNumber)
            {
                return;
            }

            BigInteger left = current * n;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (generaged.Contains(numbers[i] - left))
                {
                    result[i]++;
                }
            }
            generaged.Add(left);

            BigInteger right = current * n + 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (generaged.Contains(numbers[i] - right))
                {
                    result[i]++;
                }
            }
            generaged.Add(right);

            DFS(left);
            DFS(right);
        }
    }
}
