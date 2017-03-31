namespace Cosmetics.Tests.Products
{
    using NUnit.Framework;
    using Moq;
    using Cosmetics.Products;
    using Mocks;
    using Contracts;
    using System.Linq;

    [TestFixture]
    public class ShoppingCartTests
    {
        private FakeShoppingCart cart;
        private Mock<IProduct> mockedProduct;

        [SetUp]
        public void Initialize()
        {
            cart = new FakeShoppingCart();
            mockedProduct = new Mock<IProduct>();
            mockedProduct.Setup(x => x.Name).Returns("productName");
        }

        [Test]
        public void AddProduct_CorrectProduct_ShouldAddCorectlyToTheProductsList()
        {
            cart.AddProduct(mockedProduct.Object);

            Assert.IsTrue(cart.Products.Any(x => x.Name == "productName"));
        }

        [Test]
        public void RemoveProduct_CorrectProduct_ShouldRemoveProductCorectlyFromTheProductsList()
        {
            cart.Products.Add(mockedProduct.Object);
            cart.RemoveProduct(mockedProduct.Object);

            Assert.IsTrue(!cart.Products.Any(x => x.Name == "productName") && cart.Products.Count == 0);
        }

        [Test]
        public void ContainsProduct_CorrectProductInTheProductsList_ShouldReturnTrue()
        {
            cart.Products.Add(mockedProduct.Object);

            Assert.IsTrue(cart.ContainsProduct(mockedProduct.Object));
        }

        [Test]
        public void TotalPrice_NoProductsInTheProductList_ShouldReturn0()
        {
            int expectedPrice = 0;

            decimal actualPrice = cart.TotalPrice();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void TotalPrice_CorrectProductsInTheProductsList_ShouldReturnCorrectSumOfTheirPrices()
        {
            mockedProduct.Setup(x => x.Price).Returns(5.16m);

            var secondMockedProduct = new Mock<IProduct>();
            secondMockedProduct.Setup(x => x.Price).Returns(4.19m);

            cart.Products.Add(mockedProduct.Object);
            cart.Products.Add(secondMockedProduct.Object);

            double expectedPrice = 9.35;

            decimal actualPrice = cart.TotalPrice();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

    }
}
