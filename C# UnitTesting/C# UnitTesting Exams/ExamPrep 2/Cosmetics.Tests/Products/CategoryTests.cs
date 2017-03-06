namespace Cosmetics.Tests.Products
{
    using NUnit.Framework;
    using Moq;
    using Mocks;
    using System.Linq;
    using Contracts;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void AddCosmetics_CorrectCosmetic_ShouldAddTheCosmeticsInTheProductsList()
        {
            var mockedCosmetics = new Mock<IProduct>();
            mockedCosmetics.Setup(x => x.Name).Returns("productName");

            var category = new FakeCategory("validName");

            category.AddProduct(mockedCosmetics.Object);

            Assert.IsTrue(category.Products.Any(x=>x.Name=="productName"));

        }

        [Test]
        public void RemoveCosmetics_CorrectCosmetic_ShouldRemoveTheCosmeticsFromTheProductsList()
        {
            var mockedCosmetics = new Mock<IProduct>();
            mockedCosmetics.Setup(x => x.Name).Returns("productName");

            var category = new FakeCategory("validName");
            category.Products.Add(mockedCosmetics.Object);

            category.RemoveProduct(mockedCosmetics.Object);

            Assert.IsTrue(!category.Products.Any(x => x.Name == "productName")&&category.Products.Count==0);

        }

    }
}
