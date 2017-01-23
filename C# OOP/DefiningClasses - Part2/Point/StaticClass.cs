namespace Structure
{
    using System;
    public static class Points
    {
        public static Point3D CalculatePointDistance(Point3D point1, Point3D point2)
        {
            var distance = new Point3D();
            distance.positionX = Math.Abs(point1.positionX - point2.positionX);
            distance.positionY = Math.Abs(point1.positionY - point2.positionY);
            distance.positionZ = Math.Abs(point1.positionZ - point2.positionZ);
            return distance;
        }
    }
}
