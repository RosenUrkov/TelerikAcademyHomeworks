using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {


            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double hipo = (x - 1) * (x - 1) + (y - 1) * (y - 1);
            bool inCircle = hipo <= 1.5*1.5;

            bool inRectangle = ((x >= -1 && x <= 5) && (y >= -1 && y <= 1));
            string outputCircle = inCircle ? "inside circle" : "outside circle";
            string outputRectangle = inRectangle ? "inside rectangle" : "outside rectangle";
            Console.WriteLine("{0} {1}", outputCircle, outputRectangle);






        }
    }
}
