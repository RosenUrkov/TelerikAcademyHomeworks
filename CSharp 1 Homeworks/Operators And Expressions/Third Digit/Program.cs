using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            number /= 100;
            number %= 10;
            if(number==7)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false {0}",number);
            }
        }
    }
}
