namespace IntergalacticTravel.Tests
{
    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_WhenPassedObjectIsCorrect_ShouldDecreaseTheOwnerAmountOfResources()
        {
            int idNumber = 5;
            string nickName = "Pesho";

            var unit = new Unit(idNumber, nickName);

            unit.Resources.GoldCoins = 10;
            unit.Resources.SilverCoins = 10;
            unit.Resources.BronzeCoins = 10;

            var mockedResource = new Mock<IResources>();
            mockedResource.Setup(x => x.GoldCoins).Returns(5);
            mockedResource.Setup(x => x.SilverCoins).Returns(5);
            mockedResource.Setup(x => x.BronzeCoins).Returns(5);

            unit.Pay(mockedResource.Object);

            Assert.AreEqual(5, unit.Resources.GoldCoins);
            Assert.AreEqual(5, unit.Resources.SilverCoins);
            Assert.AreEqual(5, unit.Resources.BronzeCoins);
        }

        [Test]
        public void Pay_WhenPassedObjectIsNull_ShouldThrowNullReferenceException()
        {
            int idNumber = 5;
            string nickName = "Pesho";

            var unit = new Unit(idNumber, nickName);

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_WhenPassedObjectIsCorrect_ShouldReturnResourceObjectWithTheAmountOfResourcesInTheCost()
        {
            int idNumber = 5;
            string nickName = "Pesho";

            var unit = new Unit(idNumber, nickName);

            unit.Resources.GoldCoins = 10;
            unit.Resources.SilverCoins = 10;
            unit.Resources.BronzeCoins = 10;

            var mockedResource = new Mock<IResources>();
            mockedResource.Setup(x => x.GoldCoins).Returns(5);
            mockedResource.Setup(x => x.SilverCoins).Returns(5);
            mockedResource.Setup(x => x.BronzeCoins).Returns(5);

            var resources = unit.Pay(mockedResource.Object);

            Assert.AreEqual(5, resources.GoldCoins);
            Assert.AreEqual(5, resources.SilverCoins);
            Assert.AreEqual(5, resources.BronzeCoins);
        }
    }
}
