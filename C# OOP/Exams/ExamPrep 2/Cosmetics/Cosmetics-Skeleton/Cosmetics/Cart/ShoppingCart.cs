using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Cart
{
    public class ShoppingCart :IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return new List<IProduct>(this.productList); }
            private set { productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.productList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal sum = 0;
            foreach (var product in this.productList)
            {
                sum += product.Price;
            }
            return sum;
        }
    }
}
