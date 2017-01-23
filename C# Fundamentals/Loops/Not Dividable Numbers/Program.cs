using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_from_1_to_N
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number >= 1)
                Console.Write(1);
            for (int i = 2; i <= number; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)

                    Console.Write(" {0}", i);
            }
        }
    }
}
