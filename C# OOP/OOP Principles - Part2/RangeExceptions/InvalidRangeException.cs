namespace RangeExceptions
{
    using System;
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T startOfRange, T endOfRange) : base(message)
        {
            this.StartOfRange = startOfRange;
            this.EndOfRange = endOfRange;
        }

        public T StartOfRange { get; set; }
        public T EndOfRange { get; set; }

    }
}
