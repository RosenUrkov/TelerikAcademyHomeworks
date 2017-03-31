namespace Dealership.Models
{
    using System;
    using Dealership.Contracts;
    using Common;
    using System.Text;

    public class Car : Vehicle, ICar, IVehicle
    {
        private int seats;

        public Car(string make, string model, decimal price,int seats) :base(make,model,price)
        {
            this.Seats = seats;
            this.Type = Common.Enums.VehicleType.Car;
            this.Wheels = (int)Type;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats, 
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Seats", Constants.MinSeats, Constants.MaxSeats));
                this.seats = value;
            }
        }

        protected override string PrintSpecialInfo()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"  Seats: {this.Seats}");
            return builder.ToString().TrimEnd();
        }
        
    }
}
