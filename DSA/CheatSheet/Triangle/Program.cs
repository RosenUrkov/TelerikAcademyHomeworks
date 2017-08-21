using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Demo
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double DistanceTo(Point other)
        {
            var dx = this.X - other.X;
            var dy = this.Y - other.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public double AreaWithHeron()
        {
            var ab = A.DistanceTo(B);
            var ac = A.DistanceTo(C);
            var bc = B.DistanceTo(C);
            var p = (ab + ac + bc) / 2;

            return Math.Sqrt(p * (p - ab) * (p - ac) * (p - bc));
        }

        public double DirectedArea()
        {
            return (A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2;
        }
    }
}