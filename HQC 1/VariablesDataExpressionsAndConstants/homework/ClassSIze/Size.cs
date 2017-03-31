namespace Homework
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(Size size, double angleOfTheFigureThatWillBeRotaed)
        {
            var rotatedCos = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed));
            var rotatedSin = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed));

            var rotatedWidth = (rotatedCos * size.width) + (rotatedSin * size.height);
            var rotatedHeight = (rotatedSin * size.width) + (rotatedCos * size.height);

            return new Size(rotatedWidth, rotatedHeight);
        }
    }
}