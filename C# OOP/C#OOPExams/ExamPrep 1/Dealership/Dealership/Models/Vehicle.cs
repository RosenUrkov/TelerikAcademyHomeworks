namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Common.Enums;
    using Common;
    using System.Text;

    public abstract class Vehicle : IVehicle, IPriceable, ICommentable
    {

        private string make;
        private string model;
        private decimal price;
        private int wheels;
        private IList<IComment> comments;

        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.comments = new List<IComment>();

        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
            private set
            {
                this.comments = value;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                Validator.ValidateNull(value, "Make can not be null.");
                Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                Validator.ValidateNull(value, "Model can not be null.");
                Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));
                this.model = value;
            }

        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Price", Constants.MinPrice, Constants.MaxPrice));
                this.price = value;
            }
        }

        public VehicleType Type { get; protected set; }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            protected set
            {
                Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels", Constants.MinWheels, Constants.MaxWheels));
                this.wheels = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"  Make: {Make}");
            builder.AppendLine($"  Model: {Model}");
            builder.AppendLine($"  Wheels: {Wheels}");
            builder.AppendLine($"  Price: ${Price}");
            builder.AppendLine(this.PrintSpecialInfo());
            builder.AppendLine(this.PrintComments());
            return builder.ToString().TrimEnd();
        }

        protected abstract string PrintSpecialInfo();

        private string PrintComments()
        {
            var builder = new StringBuilder();

            if (this.Comments.Count <= 0)
            {
                builder.AppendLine("    --NO COMMENTS--");
            }
            else
            {
                builder.AppendLine( "    --COMMENTS--");
                builder.AppendLine("    ----------");
                builder.AppendLine(comments[0].ToString());

                for (int i = 1; i < this.comments.Count; i++)
                {
                    builder.AppendLine("    ----------");
                    builder.AppendLine("    ----------");
                    builder.AppendLine(comments[i].ToString());
                }
                
                builder.AppendLine("    ----------");
                builder.AppendLine("    --COMMENTS--");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
