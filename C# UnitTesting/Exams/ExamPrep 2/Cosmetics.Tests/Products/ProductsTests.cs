namespace Cosmetics.Tests.Products
{
    using Cosmetics.Products;
    using NUnit.Framework;
    using System.Text;
    using Common;
    using System.Collections.Generic;

    [TestFixture]
    public class ProductsTests
    {
        [Test]
        public void ShampooPrint_ShouldReturnStringWithTheShampooDetailsInTheRequiredFormat()
        {
            var expectedDetails = new StringBuilder();           
            expectedDetails.AppendLine(string.Format("- {0} - {1}:", "validBrand", "validName"));
            expectedDetails.AppendLine(string.Format("  * Price: ${0}", 0));
            expectedDetails.AppendLine(string.Format("  * For gender: {0}", GenderType.Men));
            expectedDetails.AppendLine(string.Format("  * Quantity: {0} ml", 0));
            expectedDetails.Append(string.Format("  * Usage: {0}", UsageType.EveryDay));

            var shampoo = new Shampoo("validName", "validBrand", 0, Common.GenderType.Men, 0, Common.UsageType.EveryDay);

            var shampooDetails = shampoo.Print();

            Assert.AreEqual(expectedDetails.ToString(), shampooDetails);

        }

        [Test]
        public void ToothpastePrint_ShouldReturnStringWithTheToothpasteDetailsInTheRequiredFormat()
        {
            var expectedDetails = new StringBuilder();
            expectedDetails.AppendLine(string.Format("- {0} - {1}:", "validBrand", "validName"));
            expectedDetails.AppendLine(string.Format("  * Price: ${0}", 0));
            expectedDetails.AppendLine(string.Format("  * For gender: {0}", GenderType.Men));
            expectedDetails.Append(string.Format("  * Ingredients: {0}", ""));

            var toothpaste = new Toothpaste("validName", "validBrand", 0, Common.GenderType.Men,new List<string>());

            var toothpasteDetails = toothpaste.Print();

            Assert.AreEqual(expectedDetails.ToString(), toothpasteDetails);

        }

        [Test]
        public void CategoryPrint_ShouldReturnStringWithTheCategoryDetailsInTheRequiredFormat()
        {
            var categoryString = string.Format("{0} category - {1} {2} in total", "validName", 0, "products");
                        
            var expectedDetails = new StringBuilder();
            expectedDetails.AppendLine(categoryString);

            var category = new Category("validName");

            var categoryDetails = category.Print();

            Assert.AreEqual(expectedDetails.ToString().TrimEnd(), categoryDetails);

        }
    }
}
