namespace Phones
{
    using Phones.PhoneParts;
    using System;
    using System.Collections.Generic;

    public class Phone
    {
        //fields        
        private int? phonePrice;
        private readonly static Phone iPhone4S;       

        //constructors
        static Phone()
        {
            iPhone4S = new Phone("iPhone", "Apple", 400, "Ivan", BatteryType.Lilon, 5, 8, 3.5, 16000000);
        }

        public Phone(string model, string manufacturer, int? price = null, string owner = null, BatteryType? batteryModel = null, int? talkedHours = null, int? idleHours = null, double? displaySize = null, int? displayColors = null)
        {
            this.PhoneModel = model;
            this.PhoneManufacturer = manufacturer;
            this.PhonePrice = price;
            this.PhoneOwner = owner;
            this.PhoneBattery = new Battery(batteryModel, talkedHours, idleHours);
            this.PhoneDisplay = new Display(displaySize, displayColors);
            this.CallHistory = new List<Call>();
        }

        public Phone() : this("Nokia", "Nokia mobile")
        {

        }

        //properties
        public string PhoneOwner { get; set; }

        public string PhoneModel { get; set; }       

        public string PhoneManufacturer { get; set; }

        public Battery PhoneBattery { get; set; }

        public Display PhoneDisplay { get; set; }

        public List<Call> CallHistory { get; set; }

        public int? PhonePrice
        {
            get
            {
                return this.phonePrice;
            }
            set
            {
                if (value > int.MaxValue)
                {
                    throw new OverflowException("Too big price for the phone.");
                }
                else if (value < 0)
                {
                    throw new ArgumentException("The price of the phone cant be negative number.");
                }
                this.phonePrice = value;
            }
        }       

        public static Phone IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }      
        
        //methods
        public override string ToString()
        {
            var dataCollector = new List<string>();
            dataCollector.Add("Phone model: " + PhoneModel);
            dataCollector.Add("Phone manufacturer: " + PhoneManufacturer);
            dataCollector.Add("Phone price: " + PhonePrice);
            dataCollector.Add("Phone owner: " + PhoneOwner);
            dataCollector.Add("Battery model: " + PhoneBattery.BatteryModel);
            dataCollector.Add("Battery hours idle: " + PhoneBattery.HoursIdle);
            dataCollector.Add("Battery hours talk: " + PhoneBattery.HoursTalk);
            dataCollector.Add("Display size: " + PhoneDisplay.DisplaySize);
            dataCollector.Add("Display colors number: " + PhoneDisplay.NumberOfColors);

            return string.Join("\r\n", dataCollector);
        }

        public void MakeCall(string number, int durationSeconds)
        {
            Call call = new Call(number, durationSeconds, DateTime.Now);
            this.CallHistory.Add(call);
        }

        public void AddCall(string number, int durationSeconds)
        {
            MakeCall(number, durationSeconds);
        }

        public void RemoveCall(int callIndexInHistory)
        {
            this.CallHistory.RemoveAt(callIndexInHistory);
        }

        public void ClearHistory()
        {
            this.CallHistory.Clear();
        }

        public double CallHistoryPrice()
        {
            double totalPrice = 0;
            foreach (var item in this.CallHistory)
            {
                totalPrice += item.DurationSeconds / 60 * Call.CallPriceMinute;
            }
            return totalPrice;
        }


    }
}
