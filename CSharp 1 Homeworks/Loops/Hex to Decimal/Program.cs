using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex_to_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexNumber = Console.ReadLine();
            long intNumber = 0;
            int currentNumber = 0;
            char[] currentHexChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            for (int i = 0; i < hexNumber.Length; i++)
            {
                for (int j = 0; j < currentHexChar.Length; j++)
                {
                    if (hexNumber[i] == currentHexChar[j])
                    {
                        currentNumber = j;
                        break;
                    }
                }
                int position = hexNumber.Length - i - 1;
                intNumber += currentNumber * (long)(Math.Pow(16, position));


            }
            Console.WriteLine(intNumber);
        }
    }
}
