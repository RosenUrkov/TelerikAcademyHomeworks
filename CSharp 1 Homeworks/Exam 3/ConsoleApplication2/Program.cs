using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentNumber = string.Empty;
            BigInteger currentSum = 1;
            BigInteger prodict = 1;
            int counter = 0;
            while (true)
            {
                currentNumber = Console.ReadLine();
                if (currentNumber == "END")
                {
                    break;
                }

                if ((counter & 1) == 0)
                {
                    for (int i = 0; i < currentNumber.Length; i++)
                    {
                        if (currentNumber[i] == '0')
                        {
                            continue;
                        }

                        currentSum *= int.Parse(currentNumber[i].ToString());

                    }
                    prodict *= currentSum;
                    currentSum = 1;
                }

                counter++;
                if (counter == 10)
                {
                    Console.WriteLine(prodict);

                    prodict = 1;
                }
            }
            Console.WriteLine(prodict);
        }
    }
}