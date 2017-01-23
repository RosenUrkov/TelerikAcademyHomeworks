namespace Dealership.Models
{
    using Common;
    using Dealership.Contracts;
    using System;
    using System.Text;

    class Truck : Vehicle, ITruck, IVehicle
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) : base(make,model,price)
        {
            this.WeightCapacity = weightCapacity;            
            this.Type = Common.Enums.VehicleType.Truck;
            this.Wheels = (int)Type;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));
                this.weightCapacity = value;
            }

        }

        protected override string PrintSpecialInfo()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"  Weight Capacity: {this.WeightCapacity}t");
            return builder.ToString().TrimEnd();
        }
       
    }
}
