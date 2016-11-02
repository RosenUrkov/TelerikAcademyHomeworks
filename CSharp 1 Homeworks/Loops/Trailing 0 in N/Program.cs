using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trailing_0_in_N
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());
            uint zeros = 0;
            int power = 1;
            System.Numerics.BigInteger factorialNumber = 1;
            while (((number / (uint)(Math.Pow(5, power))) != 0))
            {
                zeros += number / (uint)(Math.Pow(5, power));
                power++;

            }
            Console.WriteLine(zeros);


        }
    }
}
