using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            var numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            var result = new BigInteger[numbers.Sum() + 1];
            result[0] = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = result.Length - 1; j >= 0; j--)
                {
                    if (result[j] > 0)
                    {
                        result[j + numbers[i]] += result[j];
                    }
                }
            }

            BigInteger sum = 0;
            for (int i = k; i < result.Length; i++)
            {
                sum += result[i];
            }

            Console.WriteLine(sum);

            //var matrix = new BigInteger[n + 1, numbers.Sum() + 1];
            //for (int i = 1; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        if (numbers[i - 1] < j)
            //        {
            //            matrix[i, j] = matrix[i - 1, j] + matrix[i - 1, j - numbers[i - 1]];
            //        }
            //        else if (numbers[i - 1] == j)
            //        {
            //            matrix[i, j] = matrix[i - 1, j] + 1;
            //        }
            //        else if (numbers[i - 1] > j)
            //        {
            //            matrix[i, j] = matrix[i - 1, j];
            //        }
            //    }
            //}

            //BigInteger result = 0;
            //for (int i = k; i < matrix.GetLength(1); i++)
            //{
            //    result += matrix[matrix.GetLength(0) - 1, i];
            //}

            //Console.WriteLine(result);           
        }
    }
}
