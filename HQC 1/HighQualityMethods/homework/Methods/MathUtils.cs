namespace Methods
{
    using System;

    public class MathUtils
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if ((a <= 0 || b <= 0 || c <= 0) ||
                ((a + b) < c || (a + c) < b || (b + c) < a))
            {
                throw new ArgumentException("Incorrect side values of a triangle!");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        public static string NumberToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid number!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("There must be valid elements!");
            }

            int maxElement = int.MinValue;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static double CalcPointDistance(Point first, Point second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentException("Invalid points!");
            }

            double distance = Math.Sqrt(((second.X - first.X) * (second.X - first.X)) + ((second.Y - first.Y) * (second.Y - first.Y)));
            return distance;
        }
    }
}
