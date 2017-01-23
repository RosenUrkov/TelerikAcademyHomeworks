using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadratic_Equation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double discriminant = b * b - (4 * a * c);
            double firstRoot, secondRoot;
            if (discriminant<0)
            {
                Console.WriteLine("no real roots");
            }
            else if(discriminant==0)
            {
                double root = -b / (2 * a);
                Console.WriteLine("{0:f2}",root);
            }
            else
            {
                firstRoot = ((-b - Math.Sqrt(discriminant)) / (2 * a));
                secondRoot = ((-b + Math.Sqrt(discriminant)) / (2 * a));
                Console.WriteLine("{0:f2}\r\n{1:f2}",firstRoot,secondRoot);

            }
        }
    }
}
