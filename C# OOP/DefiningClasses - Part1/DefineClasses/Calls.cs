namespace Phones.PhoneParts
{
    using System;

    public class Call
    {
        //constant
        public const double CallPriceMinute = 0.37;

        //fields
        private string number;
        private int durationSeconds;
        private DateTime callTime;

        //constructor
        public Call(string number, int duration, DateTime callTime)
        {
            this.Number = number;
            this.DurationSeconds = duration;
            this.CallTime = callTime;
        }

        //properties
        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (value.Length !=10)
                {
                    throw new ArgumentException("Number must be 10 digits long.");
                }
                this.number = value;
            }
        }

        public int DurationSeconds
        {
            get
            {
                return this.durationSeconds;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Duration time cant be negative.");
                }
                this.durationSeconds = value;
            }
        }

        public DateTime CallTime
        {
            get
            {
                return this.callTime;
            }
            set
            {
               this.callTime = DateTime.Parse(value.ToString());
            }
        }

    }
}
