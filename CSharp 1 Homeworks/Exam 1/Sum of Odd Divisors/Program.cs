using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_Odd_Divisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int startOfLine = int.Parse(Console.ReadLine());
            int endOfLine = int.Parse(Console.ReadLine());


            int finalSum = 0;

            for (int i = startOfLine; i <= endOfLine; i++)
            {
                int currentSum = 0;
                //if ((i & 1) == 1)
                //{
                //    currentSum++;
                //}

                for (int j = 1; j <= i; j += 2)
                {
                    if (i % j == 0)
                    {
                        currentSum += j;
                    }

                }
                finalSum += currentSum;

            }
            Console.WriteLine(finalSum);

        }
    }
}
