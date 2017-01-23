namespace Structure
{
    using System.Collections.Generic;
    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            points = new List<Point3D>();
        }

        public Path(Point3D point) : this()
        {
            AddPoint(point);
        }

        public Path(List<Point3D> points) : this()
        {
            this.points = points;
        }

        public List<Point3D> Points
        {
            get
            {
                return this.points;
            }
        }

        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }
    }
}
