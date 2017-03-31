namespace Cosmetics.Tests.Engine
{
    using NUnit.Framework;
    using Moq;
    using Cosmetics.Engine;
    using System;
    using Products;
    using System.Collections.Generic;
    using Cosmetics.Products;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        private CosmeticsFactory factory;

        [SetUp]
        public void Initialize()
        {
            factory = new CosmeticsFactory();
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_PassedNameParameterIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidName)
        {           
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(invalidName, "validBrand", 0, Common.GenderType.Men, 0, Common.UsageType.EveryDay));
        }

        [TestCase("no")]
        [TestCase("invalidNameLength")]
        public void CreateShampoo_PassedNameLengthIsOutOfRange_ShouldThrowIndexOutOfRangeException(string invalidName)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(invalidName, "validBrand", 0, Common.GenderType.Men, 0, Common.UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_PassedBrandParameterIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidBrand)
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("validName", invalidBrand, 0, Common.GenderType.Men, 0, Common.UsageType.EveryDay));
        }

        [TestCase("n")]
        [TestCase("invalidBrandLength")]
        public void CreateShampoo_PassedBrandLengthIsOutOfRange_ShouldThrowIndexOutOfRangeException(string invalidBrand)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("validName", invalidBrand, 0, Common.GenderType.Men, 0, Common.UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_AllPassedParametersAreValid_ShouldReturnNewShapoo()
        {
            var shampoo = factory.CreateShampoo("validName", "validBrand", 0, Common.GenderType.Men, 0, Common.UsageType.EveryDay);

            Assert.IsInstanceOf(typeof(Shampoo), shampoo);   
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_PassedNameParameterIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidName)
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(invalidName));
        }

        [TestCase("n")]
        [TestCase("nameLengthIsMoreThan15")]
        public void CreateCategory_PassedNameLengthIsOutOfRange_ShouldThrowIndexOutOfRangeException(string invalidName)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(invalidName));
        }

        [Test]
        public void CreateCategory_NameIsValid_ShouldReturnNewCategory()
        {
            var category = factory.CreateCategory("validName");

            Assert.IsInstanceOf(typeof(Category), category);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_PassedNameParameterIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidName)
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(invalidName, "validBrand", 0, Common.GenderType.Men,new List<string> ()));
        }

        [TestCase("no")]
        [TestCase("invalidNameLength")]
        public void CreateToothpaste_PassedNameLengthIsOutOfRange_ShouldThrowIndexOutOfRangeException(string invalidName)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(invalidName, "validBrand", 0, Common.GenderType.Men, new List<string>()));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_PassedBrandParameterIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidBrand)
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste("validName", invalidBrand, 0, Common.GenderType.Men, new List<string>()));
        }

        [TestCase("n")]
        [TestCase("invalidBrandLength")]
        public void CreateToothpaste_PassedBrandLengthIsOutOfRange_ShouldThrowIndexOutOfRangeException(string invalidBrand)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("validName", invalidBrand, 0, Common.GenderType.Men, new List<string>()));
        }

        [TestCase("no")]
        [TestCase("invalidIngredientNameLength")]
        public void CreateToothpaste_PassedItemsNamesAreNotInTheCorrectBounderies_ShouldThrowIndexOutOfRangeException(string ingredient)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("validName", "validBrand", 0, Common.GenderType.Men, new List<string> {ingredient }));
        }

        [Test]
        public void CreateShoppingCart_ShouldAlwaysReturnAShopingCart()
        {
            var cart = factory.CreateShoppingCart();

            Assert.IsInstanceOf(typeof(ShoppingCart), cart);
        }
    }
}
