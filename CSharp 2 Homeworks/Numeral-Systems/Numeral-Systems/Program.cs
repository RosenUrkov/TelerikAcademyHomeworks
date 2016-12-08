using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numeral_Systems
{
    class Program
    {
        static void Main(string[] args)
        {
            int startBase = int.Parse(Console.ReadLine());
            string numberToConvert = Console.ReadLine();
            int endBase = int.Parse(Console.ReadLine());
            BigInteger toDecimal = ConvertToDec(numberToConvert, startBase);
            string fromDecimal = ConvertFromDec(toDecimal, endBase);
            Console.WriteLine(fromDecimal);


        }

        static BigInteger ConvertToDec(string number, int numericBase)
        {
            BigInteger result = 0;

            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            for (int i = 0; i < number.Length; i++)
            {
                result = result * numericBase + Array.IndexOf(digits, number[i]);
            }
            return result;

        }

        static string ConvertFromDec(BigInteger number, int numericBase)
        {
            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            string result = string.Empty;
            while (number != 0)
            {
                BigInteger digit = number % numericBase;
                number /= numericBase;
                for (int i = 0; i < digits.Length; i++)
                {
                    if (i == digit)
                    {
                        result = digits[i] + result;
                        break;
                    }
                }
            }
            return result;

        }
    }
}
