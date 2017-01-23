using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birds_and_feathers
{
    class Program
    {
        static void Main(string[] args)
        {
            double birds = double.Parse(Console.ReadLine());
            double feathers = double.Parse(Console.ReadLine());
            double averageFeathers = (feathers / birds);
            if (birds % 2 == 0)
            {
                averageFeathers *= 123123123123;
            }
            else
            {
                averageFeathers /= 317;
            }
            Console.WriteLine("{0:f4}",averageFeathers);
        }
    }
}
