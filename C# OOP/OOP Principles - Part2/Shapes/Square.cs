namespace Shapes
{
    public class Square : Shape
    {
        public Square(double size)
            : base(size, size)
        {

        }

        public override double CalculateSurface()
        {
            return Height * Width;
        }
    }
}
