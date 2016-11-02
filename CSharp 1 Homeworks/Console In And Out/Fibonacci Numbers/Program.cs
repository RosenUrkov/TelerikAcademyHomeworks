using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {





            long number = long.Parse(Console.ReadLine());
            long a = 0;
            long b = 1;


            Console.Write(a);

            if (number > 1)
            {
                Console.Write(", {0}", b);
            }

            for (int i = 0; i < number - 2; i++)
            {
                if (!((i & 1) == 1))
                {
                    Console.Write(", {0}", a += b);

                }
                else
                {
                    Console.Write(", {0}", b += a);
                }
            }


        }
    }
}
