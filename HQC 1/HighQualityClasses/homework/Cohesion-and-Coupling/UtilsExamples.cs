namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                GeometricUtils.CalcDistance2D(new Point2D(1, -2), new Point2D(3, 4)));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                GeometricUtils.CalcDistance3D(new Point3D(5, 2, -1), new Point3D(3, -6, 4)));

            double x = 3;
            double y = 4;
            double z = 5;

            Console.WriteLine("Volume = {0:f2}", GeometricUtils.CalcVolume(x, y, z));
            Console.WriteLine("Diagonal XYZ = {0:f2}", GeometricUtils.CalcDistance3D(new Point3D(0, 0, 0), new Point3D(x, y, z)));
            Console.WriteLine("Diagonal XY = {0:f2}", GeometricUtils.CalcDistance2D(new Point2D(0, 0), new Point2D(x, y)));
            Console.WriteLine("Diagonal XZ = {0:f2}", GeometricUtils.CalcDistance2D(new Point2D(0, 0), new Point2D(x, z)));
            Console.WriteLine("Diagonal YZ = {0:f2}", GeometricUtils.CalcDistance2D(new Point2D(0, 0), new Point2D(y, z)));
        }
    }
}
