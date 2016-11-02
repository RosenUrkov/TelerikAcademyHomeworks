using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutant_Squirals
{
    class Program
    {
        static void Main(string[] args)
        {
            double trees = double.Parse(Console.ReadLine());
            double branches = double.Parse(Console.ReadLine());
            double squirrel = double.Parse(Console.ReadLine());
            double averigeTails = double.Parse(Console.ReadLine());
            double result = trees* branches * squirrel * averigeTails;
            if (result % 2 == 0)
            {
                Console.WriteLine("{0:f3}", result * 376439);
            }
            else
            {
                Console.WriteLine("{0:f3}", result / 7);
            }



        }
    }
}
