namespace Phones.PhoneParts
{
    using System;
    public class Battery
    {
        //constant
        //private const int ТotalBatteryHours = 100;

        //fields       
        private int? hoursIdle;
        private int? hoursTalk;

        //constructor
        public Battery(BatteryType? model, int? talkHours, int? idleHours)
        {
            this.BatteryModel = model;
            this.HoursTalk = talkHours;
            this.HoursIdle = idleHours;
        }

        //properties
        public BatteryType? BatteryModel { get; set; }
        

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Hours talked cant be that big number.");
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours talked cant be negative number.");
                }
                this.hoursTalk = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Idle hours cant be that big number.");
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Idle hours cant be negative number.");
                }
                this.hoursIdle = value;
            }

        }
    }
}
