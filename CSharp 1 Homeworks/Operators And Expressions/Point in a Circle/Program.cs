using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            float x = float.Parse(Console.ReadLine());
            float y = float.Parse(Console.ReadLine());
            float point =(float)Math.Sqrt( x * x + y * y);
            Console.WriteLine(point<=Math.Sqrt(8) ? "yes {0:f2}" : "no {0:f2}" , point);
        }
    }
}
