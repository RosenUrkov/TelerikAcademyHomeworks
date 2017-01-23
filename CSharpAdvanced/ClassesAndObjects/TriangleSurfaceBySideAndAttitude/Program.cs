using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSurfaceBySideAndAttitude
{
    class Triangle
    {
        private double side;
        private double altitude;

        public double Side
        {
            get
            {
                return this.side;
            }

            set
            {
                this.side = value;
            }
        }

        public double Altitude
        {
            get
            {
                return this.altitude;
            }

            set
            {
                this.altitude = value;
            }
        }

        public Triangle(double side, double altitude)
        {
            this.Side = side;
            this.Altitude = altitude;
        }

        public double Area()
        {
            return Side * Altitude / 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double sideOfTriangle = double.Parse(Console.ReadLine());
            double altitudeOfTriangle = double.Parse(Console.ReadLine());
            Triangle myTriangle = new Triangle(sideOfTriangle, altitudeOfTriangle);
            double area = myTriangle.Area();
            Console.WriteLine("{0:f2}", area);
        }
    }
}
