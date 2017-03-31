using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biggest_of_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());
            if (a >= b && a >= c && a >= d && a >= e)
            {
                Console.WriteLine(a);
            }
            else if (b >= a && b >= c && b >= d && b >= e)
            {
                Console.WriteLine(b);
            }
            else if (c >= a && c >= b && c >= d && c >= e)
            {
                Console.WriteLine(c);
            }
            else if (d >= a && d >= c && d >= b && d >= e)
            {
                Console.WriteLine(d);
            }
            else if (e >= a && e >= c && e >= d && e >= b)
            {
                Console.WriteLine(e);
            }
        }
    }
}
