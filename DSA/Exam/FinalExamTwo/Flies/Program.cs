using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flies
{
    class Pair
    {
        public Pair(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double x { get; set; }

        public double y { get; set; }

        public override string ToString()
        {
            return string.Format("{0:F4} {1:F4}", this.x, this.y);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var flies = new List<Pair>();

            var fly = Console.ReadLine().Split(' ');
            var A = new Pair(double.Parse(fly[0]), double.Parse(fly[1]));

            fly = Console.ReadLine().Split(' ');
            var B = new Pair(double.Parse(fly[0]), double.Parse(fly[1]));

            fly = Console.ReadLine().Split(' ');
            var C = new Pair(double.Parse(fly[0]), double.Parse(fly[1]));

            double yDelta_a = B.y - A.y;
            double xDelta_a = B.x - A.x;
            double yDelta_b = C.y - B.y;
            double xDelta_b = C.x - B.x;

            double aSlope = yDelta_a / xDelta_a;
            double bSlope = yDelta_b / xDelta_b;

            var center = new Pair(0, 0);
            center.x = (aSlope * bSlope * (A.y - C.y) + bSlope * (A.x + B.x)
                        - aSlope * (B.x + C.x)) / (2 * (bSlope - aSlope));
            center.y = -1 * (center.x - (A.x + B.x) / 2) / aSlope + (A.y + B.y) / 2;

            Console.WriteLine(center);
        }
    }
}
