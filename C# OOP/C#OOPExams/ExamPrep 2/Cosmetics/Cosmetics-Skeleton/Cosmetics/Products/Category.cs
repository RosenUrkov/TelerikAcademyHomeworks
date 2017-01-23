using System;
using Cosmetics.Contracts;
using Cosmetics.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private string name;
        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            products = new List<IProduct>();

        }

        public string Name
        {
            get
            {
                return this.name;               
            }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));
                Validator.CheckIfStringLengthIsValid(value, 15, 2, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15));
                this.name = value;
            }
        }

        public ICollection<IProduct> Products
        {
            get
            {
                return new List<IProduct>(this.products);
            }
            private set
            {
                this.products = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.products.Add(cosmetics);
            SortCosmetics();
        }

        public string Print()
        {
            var builder = new StringBuilder();
            builder.Append($" {this.name} category - {this.Products.Count} ");
            if (this.Products.Count == 1)
            {
                builder.Append("product");
            }
            else
            {
                builder.Append("products");
            }
            builder.AppendLine(" in total");

            foreach (var product in this.Products)
            {
                builder.AppendLine(product.Print());
            }
            return builder.ToString().Trim();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            if (!Products.Contains(cosmetics))
            {
                throw new ArgumentException($"Product {cosmetics.Name} does not exist in category {this.Name}!");
            }
            this.products.Remove(cosmetics);
            SortCosmetics();
        }

        private void SortCosmetics()
        {
            this.products = this.products.OrderBy(x => x.Brand).ThenByDescending(x => x.Price).ToList();   
        }
    }
}
