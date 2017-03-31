namespace CohesionAndCoupling
{
    public class Point3D : Point2D
    {
        public Point3D(double x, double y, double z) : base(x, y)
        {
            this.Z = z;
        }

        public double Z { get; private set; }
    }
}
