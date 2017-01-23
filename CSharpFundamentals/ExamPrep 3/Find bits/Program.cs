using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_bits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numbersCount = int.Parse(Console.ReadLine());

            int counterOfOcurrences = 0;

           //while(true)
                for (int i = 0; i < numbersCount; i++)
            {
                long currentNumber = long.Parse(Console.ReadLine());
                int mask = ((1 << 5) - 1);
                int targetNumber = number & mask;

                for (int j = 0; j < 25; j++)
                {
                    //Console.WriteLine(Convert.ToString(currentNumber,2));
                    //Console.WriteLine(Convert.ToString(mask<<j,2));
                    //Console.WriteLine("----------------------------------");
                    if ((currentNumber & (mask << j)) == (targetNumber << j))
                    {
                        counterOfOcurrences++;
                    }
                }
            }
            Console.WriteLine(counterOfOcurrences);
        }
    }
}
