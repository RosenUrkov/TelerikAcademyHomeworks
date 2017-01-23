namespace Phones.PhoneParts
{
    using System;

    public class Display
    {
        //fields
        private double? displaySize;
        private int? numberOfColors;

        //constructor
        public Display(double? size, int? colorsNumber)
        {
            this.DisplaySize = size;
            this.NumberOfColors = colorsNumber;
        }

        //properties
        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value > int.MaxValue)
                {
                    throw new OverflowException("The phone cant have that much colors.");
                }
                else if (value < 1)
                {
                    throw new ArgumentException("The phone cant have less than 1 color");
                }
                this.numberOfColors = value;
            }
        }

        public double? DisplaySize
        {
            get
            {
                return this.displaySize;
            }
            set
            {
                if (value > int.MaxValue)
                {
                    throw new OverflowException("The phone cant be that big int size.");
                }
                else if (value < 1)
                {
                    throw new ArgumentException("The phone cant be that small in size.");
                }
                this.displaySize = value;
            }
        }

    }
}
