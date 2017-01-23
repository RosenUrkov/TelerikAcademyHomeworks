namespace DefineClasses
{
    using Structure;
    using System;
    public class MainClass
    {
        public static void Main()
        {
            Point3D myPoint = new Point3D();
            Point3D myPoint2 = new Point3D(5,7,8);
            Console.WriteLine( Points.CalculatePointDistance(myPoint, myPoint2));
            Console.WriteLine("-----------------------------------------------------------");

            var myPath = new Path(myPoint);
            myPath.AddPoint(myPoint2);

            PathStorage.SavePath(myPath);
            Console.WriteLine(PathStorage.LoadPath());
        }
    }
}
