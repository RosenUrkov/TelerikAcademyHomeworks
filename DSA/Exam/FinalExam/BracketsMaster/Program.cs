using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BracketsMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n % 2 == 1 || n == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var halfFactorial = 0;
            var halfFactCoef = 0;

            var factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
                if (i == n / 2)
                {
                    halfFactorial = factorial;
                    halfFactCoef = i + 1;
                }
            }

            BigInteger result = factorial / (halfFactorial * halfFactorial * halfFactCoef);

            var x = result;
            for (int i = 0; i < x; i++)
            {
                result *= 4;
            }

            Console.WriteLine(result);
        }
    }
}
