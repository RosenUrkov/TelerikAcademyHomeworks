namespace Structure
{
    using System.Text;
    public struct Point3D
    {
        private static readonly Point3D pointO;

        static Point3D()
        {
            pointO = new Point3D();
        }

        public Point3D(int X, int Y, int Z)
        {
            this.positionX = X;
            this.positionY = Y;
            this.positionZ = Z;                   
        }       

        public int positionX { get; set; }
        public int positionY { get; set; }
        public int positionZ { get; set; }
        public static Point3D O
        {
            get
            {
                return pointO;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"X = {positionX}" + ", ");
            builder.Append($"Y = {positionY}" + ", ");
            builder.Append($"Z = {positionZ}"+";");
            return builder.ToString();
        }
    }
}
