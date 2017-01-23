using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] arrayOfNumbers = new int[number];
            int maxSum = 0;
            int currentSum = 0;
            for (int i = 0; i < number; i++)
            {
                arrayOfNumbers[i] = int.Parse(Console.ReadLine());
                currentSum += arrayOfNumbers[i];
                if (currentSum < 0)
                {
                    currentSum = 0;

                }
                else if (currentSum > 0)
                {
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
                if (number - 1 == i)
                {
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }

            }
            Console.WriteLine(maxSum);
        }
    }
}
