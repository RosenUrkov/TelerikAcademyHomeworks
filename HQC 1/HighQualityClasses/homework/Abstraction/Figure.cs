namespace Abstraction
{
    using System;

    public abstract class Figure : IFigure
    {
        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        protected void ValidateInputNumber(double number, string message)
        {
            if (number <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
