using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryShort
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string stringNumber = Binary(number);
            Console.WriteLine(stringNumber);

        }

        static string Binary(long number)
        {
            string result = string.Empty;
            if (number >= 0)
            {
                do
                {
                    long digit = number % 2;
                    number /= 2;
                    result = digit + result;
                } while (number != 0);
                return result.PadLeft(16, '0');
            }
            else
            {
                number = (65536 + number);
                do
                {
                    long digit = number % 2;
                    number /= 2;
                    result = digit + result;
                } while (number != 0);

                return result;
            }


        }
    }
}
