namespace Shapes
{
    using System.Collections.Generic;
    public class MainClass
    {
        public static void Main()
        {
            var shapes = new List<Shape>();
            shapes.Add(new Triangle(5.6, 8));
            shapes.Add(new Rectangle(4.25, 6.5));
            shapes.Add(new Square(5));

            foreach (var shape in shapes)
            {
                System.Console.WriteLine(shape.CalculateSurface());
            }  
        }
    }
}
