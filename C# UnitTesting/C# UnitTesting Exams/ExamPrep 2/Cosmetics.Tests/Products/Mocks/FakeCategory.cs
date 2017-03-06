using Cosmetics.Contracts;
using Cosmetics.Products;
using System.Collections.Generic;

namespace Cosmetics.Tests.Products.Mocks
{
    internal class FakeCategory : Category
    {
        public FakeCategory(string name) : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
