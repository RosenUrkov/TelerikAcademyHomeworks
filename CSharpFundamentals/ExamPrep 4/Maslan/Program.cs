using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Maslan
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            Byte transformations = 0;
            bool isDigitOne = false;


            for (int i = 0; i < 10; i++)
            {

                BigInteger maxSum = 1;

                for (int j = 0; number.Length > 1; j++)
                {
                    int currentSum = 0;
                    number = number.Remove(number.Length - 1);

                    for (int counter = 1; counter < number.Length; counter += 2)
                    {
                        currentSum += number[counter] - '0';
                    }

                    if (currentSum != 0)
                    {
                        maxSum *= currentSum;
                    }

                }
                number = Convert.ToString(maxSum);
                transformations++;
                if (number.Length==1)
                {
                    isDigitOne = true;
                    break;
                }

            }
            if (isDigitOne)
            {
                Console.WriteLine("{0}\r\n{1}", transformations, number);
            }
            else
            {
                Console.WriteLine("{0}", number);
            }
        }
    }
}
