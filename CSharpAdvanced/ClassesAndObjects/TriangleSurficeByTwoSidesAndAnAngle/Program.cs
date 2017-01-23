using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSurficeByTwoSidesAndAnAngle
{
    class Triangle
    {
        private double firstSide;
        private double secondSide;
        private double angle;

        public double FirstSide
        {
            get
            {
                return this.firstSide;
            }

            set
            {
                this.firstSide = value;
            }
        }

        public double SecondSide
        {
            get
            {
                return this.secondSide;
            }

            set
            {
                this.secondSide = value;
            }
        }

        public double Angle
        {
            get
            {
                return this.angle;
            }

            set
            {
                this.angle = value;
            }
        }

        public Triangle(double first, double second, double angle)
        {
            this.FirstSide = first;
            this.SecondSide = second;
            this.Angle = angle;
        }

        public double Area()
        {
            double area = FirstSide * SecondSide * Math.Sin(Math.PI * Angle / 180) / 2;
            return area;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle myTriangle = new Triangle(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Console.WriteLine("{0:f2}", myTriangle.Area());
        }
    }
   
}
