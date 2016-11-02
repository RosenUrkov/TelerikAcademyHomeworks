using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_to_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bit = 0;
            string binaryNumber = string.Empty;
            while (number != 0)
            {
                bit = number % 2;
                number /= 2;
                binaryNumber = bit + binaryNumber;
            }
            Console.WriteLine(binaryNumber);

        }
    }
}
