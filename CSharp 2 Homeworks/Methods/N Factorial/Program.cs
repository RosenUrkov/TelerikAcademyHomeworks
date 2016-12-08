using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace N_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                BigInteger factorialSum = Factorial(number);
                Console.WriteLine(factorialSum);
            }
        }

        static BigInteger Factorial(int number)
        {
            if (number == 1)
            {
                return number;
            }
            BigInteger sum = number * Factorial(number - 1);
            return sum;
        }
    }
}
