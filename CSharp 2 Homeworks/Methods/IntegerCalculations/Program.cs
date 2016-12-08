using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("{0}", Minimum(numbers));
            Console.WriteLine("{0}", Maximal(numbers));
            Console.WriteLine("{0:f2}", Average(numbers));
            Console.WriteLine("{0}", Sum(numbers));
            Console.WriteLine("{0}", Product(numbers));


        }

        static int Minimum(int[] array)
        {
            int minimal = int.MaxValue;
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] < minimal)
                {
                    minimal = array[index];
                }

            }
            return minimal;
        }

        static int Maximal(int[] array)
        {
            int maximal = int.MinValue;
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] > maximal)
                {
                    maximal = array[index];
                }

            }
            return maximal;
        }

        static double Average(int[] array)
        {
            double average = 0;
            int sum = 0;
            for (int index = 0; index < array.Length; index++)
            {
                sum += array[index];

            }
            average = sum / (double)array.Length;
            return average;
        }

        static int Sum(int[] array)
        {
            int sum = 0;
            for (int index = 0; index < array.Length; index++)
            {
                sum += array[index];

            }
            return sum;
        }

        static long Product(int[] array)
        {
            long product = 1;
            for (int index = 0; index < array.Length; index++)
            {
                product *= array[index];

            }
            return product;
        }
    }
}
