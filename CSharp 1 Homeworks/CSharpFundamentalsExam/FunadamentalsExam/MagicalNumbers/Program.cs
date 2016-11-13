using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int firstDigit = number % 10;
            int secondDigit = number / 10;
            int thirdDigit = secondDigit / 10;
            secondDigit = secondDigit % 10;

            if ((secondDigit % 2) == 1)
            {
                Console.WriteLine("{0:f2}", (thirdDigit * secondDigit) / (double)firstDigit);
            }
            else
            {
                Console.WriteLine("{0:f2}", (thirdDigit + secondDigit) * (double)firstDigit);
            }
        }
    }
}
