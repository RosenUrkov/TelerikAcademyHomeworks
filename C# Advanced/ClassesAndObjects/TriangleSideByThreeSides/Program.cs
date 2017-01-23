using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSideByThreeSides
{
    class Triangle
    {
        private double firstSide;
        private double secondSide;
        private double thirdSide;

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

        public double ThirdSide
        {
            get
            {
                return this.thirdSide;
            }

            set
            {
                this.thirdSide = value;
            }
        }

        public Triangle(double first, double second, double third)
        {
            this.FirstSide = first;
            this.SecondSide = second;
            this.ThirdSide = third;
        }

        public double Area()
        {
            double halfPerim = (FirstSide + SecondSide + ThirdSide) / 2;
            double result = Math.Sqrt(halfPerim * (halfPerim - FirstSide) * (halfPerim - SecondSide) * (halfPerim - ThirdSide));
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());

            Triangle myTriangle = new Triangle(first, second, third);
            double area = myTriangle.Area();
            Console.WriteLine("{0:f2}", area);


        }
    }
}
