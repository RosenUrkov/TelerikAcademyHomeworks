using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = a;
            a = b;
            b = c;
            Console.WriteLine(a<b ? "{0} {1}" : "{1} {0}",a, b);
        }
    }
}
