namespace Cosmetics.Tests.Engine
{
    using NUnit.Framework;
    using Moq;
    using Contracts;
    using Cosmetics.Engine;
    using System.Collections.Generic;
    using System.Linq;
    using Products;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        private Mock<ICosmeticsFactory> mockedFactory;
        private Mock<IShoppingCart> mockedShoppingCart;
        private Mock<ICommandParser> mockedCommandParser;

        [SetUp]
        public void Initialize()
        {
            mockedFactory = new Mock<ICosmeticsFactory>();
            mockedShoppingCart = new Mock<IShoppingCart>();
            mockedCommandParser = new Mock<ICommandParser>();
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsCreateCategoryCommand_ShouldReadParseAndExecuteCreateCategoryCommandAndAddNewCategoryInTheListOfCategories()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("CreateCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "categoryName" });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // act
            engine.Start();

            // assert
            Assert.IsTrue(engine.Categories.Any(x => x.Key == "categoryName"));
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsAddToCategoryCommand_ShouldReadParseAndExecuteAddToCategoryCommandAndAddTheSelectedProductInTheRespectiveCategory()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("AddToCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "categoryName", "productName" });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            var mockedCategory = new Mock<ICategory>();
            engine.Categories.Add("categoryName", mockedCategory.Object);

            var mockedProduct = new Mock<IProduct>();
            engine.Products.Add("productName", mockedProduct.Object);

            // act
            engine.Start();

            // assert
            mockedCategory.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsRemoveFromCategoryCommand_ShouldReadParseAndExecuteRemoveFromCategoryCommandAndRemoveTheSelectedProductFromTheRespectiveCategory()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("RemoveFromCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "categoryName", "productName" });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            var mockedCategory = new Mock<ICategory>();
            engine.Categories.Add("categoryName", mockedCategory.Object);

            var mockedProduct = new Mock<IProduct>();
            engine.Products.Add("productName", mockedProduct.Object);

            // act
            engine.Start();

            // assert
            mockedCategory.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsShowCategoryCommand_ShouldReadParseAndExecuteShowCategoryCommandAndShowTheSelectedCategory()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("ShowCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "categoryName" });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            var mockedCategory = new Mock<ICategory>();
            engine.Categories.Add("categoryName", mockedCategory.Object);

            // act
            engine.Start();

            // assert
            mockedCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsCreateShampooCommand_ShouldReadParseAndExecuteCreateShampooCommandAndAddNewShampooInTheListOfProducts()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("CreateShampoo");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "shampooName", "shampooBrand", "0", "men", "0", "everyday" });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // act
            engine.Start();

            // assert
            Assert.IsTrue(engine.Products.Any(x => x.Key == "shampooName"));
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsCreateToothpasteCommand_ShouldReadParseAndExecuteCreateToothpasteCommandAndAddNewToothpasteInTheListOfProducts()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("CreateToothpaste");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "toothpasteName", "toothpasteBrand", "0", "men", "0", "everyday" });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // act
            engine.Start();

            // assert
            Assert.IsTrue(engine.Products.Any(x => x.Key == "toothpasteName"));
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsAddToShoppingCartCommand_ShouldReadParseAndExecuteAddToShoppingCartCommandAndAddTheSelectedProductInTheShoppingCart()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("AddToShoppingCart");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "productName"});

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            var mockedProduct = new Mock<IProduct>();
            engine.Products.Add("productName", mockedProduct.Object);

            // act
            engine.Start();

            // assert
            mockedShoppingCart.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once());
        }

        [Test]
        public void Start_InputStringIsInTheFormatThatRepresentsRemoveFromShoppingCartCommand_ShouldReadParseAndExecuteRemoveFromShoppingCartCommandAndRemoveTheSelectedProductFromTheShoppingCart()
        {
            // arrange        
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("RemoveFromShoppingCart");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { "productName" });

            mockedShoppingCart.Setup(x => x.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { mockedCommand.Object });

            var engine = new FakeCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            var mockedProduct = new Mock<IProduct>();
            engine.Products.Add("productName", mockedProduct.Object);

            // act
            engine.Start();

            // assert
            mockedShoppingCart.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once());
        }
    }
}
