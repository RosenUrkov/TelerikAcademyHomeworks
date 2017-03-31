using Cosmetics.Contracts;
using Cosmetics.Engine;
using System.Collections.Generic;

namespace Cosmetics.Tests.Engine
{
    internal class FakeCosmeticsEngine : CosmeticsEngine
    {
        public FakeCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser) :
            base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return this.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return this.products;
            }
        }

    }
}
