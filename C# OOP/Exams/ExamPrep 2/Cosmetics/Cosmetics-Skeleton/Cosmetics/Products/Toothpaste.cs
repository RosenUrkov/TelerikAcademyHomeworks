using System;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System.Text;
using System.Collections.Generic;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) : base(name, brand, price, gender)
        {
            //CheckIngredients(ingredients);
            this.ingredients = string.Join(", ", ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Each ingredient"));
                Validator.CheckIfStringLengthIsValid(value, 12, 4, String.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", 4, 12));
                this.ingredients += ", " + value;
            }
        }

        private void CheckIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringIsNullOrEmpty(ingredient, String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Each ingredient"));
                Validator.CheckIfStringLengthIsValid(ingredient, 12, 4, String.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", 4, 12));
            }
        }

        public override string Print()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.Print());
            builder.AppendLine($"  * Ingredients: {this.Ingredients}");

            return builder.ToString().Trim();
        }
    }
}
