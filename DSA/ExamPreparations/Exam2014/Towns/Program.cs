using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new int[n];
            var longestIncreasingSubsequence = new int[n];
            var longestDecreasingSubsequence = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine().Split(' ')[0]);

                longestIncreasingSubsequence[i] = 1;
                longestDecreasingSubsequence[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        longestIncreasingSubsequence[i] = Math.Max(
                                                        longestIncreasingSubsequence[j] + 1,
                                                        longestIncreasingSubsequence[i]);
                    }
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (numbers[j] < numbers[i])
                    {
                        longestDecreasingSubsequence[i] = Math.Max(
                                                    longestDecreasingSubsequence[j] + 1,
                                                    longestDecreasingSubsequence[i]);
                    }
                }
            }

            var result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = longestIncreasingSubsequence[i] + longestDecreasingSubsequence[i] - 1;
            }

            Console.WriteLine(result.Max());
        }
    }
}
