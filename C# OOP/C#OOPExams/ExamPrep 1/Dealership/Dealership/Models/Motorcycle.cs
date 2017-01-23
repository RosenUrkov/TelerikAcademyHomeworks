namespace Dealership.Models
{
    using Common;
    using Dealership.Contracts;
    using System;
    using System.Text;

    class Motorcycle : Vehicle, IMotorcycle, IVehicle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category) :base(make,model,price)
        {
            this.Category = category;
            this.Type = Common.Enums.VehicleType.Motorcycle;
            this.Wheels = (int)Type;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                Validator.ValidateNull(value, "Category can not be null.");
                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength, 
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));
                this.category = value;
            }
        }

        protected override string PrintSpecialInfo()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"  Category: {this.Category}");
            return builder.ToString().TrimEnd();
        }
       
    }
}
