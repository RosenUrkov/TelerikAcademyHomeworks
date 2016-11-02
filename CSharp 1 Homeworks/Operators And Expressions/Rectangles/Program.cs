using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double area = height * width;
            double perimeter = 2*(height + width);
            Console.WriteLine("{0:f2} {1:f2}",area , perimeter);

        }
    }
}
