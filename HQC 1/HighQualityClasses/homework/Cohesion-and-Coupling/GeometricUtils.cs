namespace CohesionAndCoupling
{
    using System;

    public static class GeometricUtils
    {
        public static double CalcDistance2D(Point2D first, Point2D second)
        {
            double distance = Math.Sqrt(
                ((second.X - first.X) * (second.X - first.X)) +
               ((second.Y - first.Y) * (second.Y - first.Y)));

            return distance;
        }

        public static double CalcDistance3D(Point3D first, Point3D second)
        {
            double distance = Math.Sqrt(
                ((second.X - first.X) * (second.X - first.X)) +
               ((second.Y - first.Y) * (second.Y - first.Y)) +
                ((second.Z - first.Z) * (second.Z - first.Z)));

            return distance;
        }

        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }
    }
}
