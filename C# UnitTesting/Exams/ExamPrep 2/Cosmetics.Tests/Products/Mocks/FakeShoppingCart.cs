using Cosmetics.Contracts;
using Cosmetics.Products;
using System.Collections.Generic;

namespace Cosmetics.Tests.Products.Mocks
{
    internal class FakeShoppingCart:ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
