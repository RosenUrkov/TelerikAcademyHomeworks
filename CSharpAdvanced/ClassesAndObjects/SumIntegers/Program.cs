using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumIntegers
{
    class SumIntegers
    {

        public static long SumNumbers(int[] numbersArray)
        {
            long sum = 0;

            for (int i = 0; i < numbersArray.Length; i++)
            {
                sum += numbersArray[i];
            }

            return sum;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            long sum = SumIntegers.SumNumbers(numbers);
            Console.WriteLine(sum);

        }
    }
}
