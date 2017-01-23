using System;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System.Text;

namespace Cosmetics.Products
{
    public class Product : IProduct
    {
        private string brand;
        private string name;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;   
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product brand"));
                Validator.CheckIfStringLengthIsValid(value, 10, 2, String.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10));
                this.brand = value;
            }
        }

        public GenderType Gender { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));
                Validator.CheckIfStringLengthIsValid(value, 10, 3, String.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10));
                this.name = value;
            }
        }

        public decimal Price { get; protected set; }

        public virtual string Print()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"- {this.Brand} - {this.Name}:");
            builder.AppendLine($"  * Price: ${this.Price}");
            builder.AppendLine($"  * For gender: {this.Gender}");

            return builder.ToString().Trim();
        }
    }
}
