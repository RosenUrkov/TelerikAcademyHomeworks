namespace IntergalacticTravel.Tests
{
    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System.Collections.Generic;

    [TestFixture]
    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProfits_ShouldIncreaseTheOwnersResourcesByTheAmountOfResourcesGeneratedFromHisTeleportStations()
        {
            // arrange
            int idNumber = 5;
            string nickName = "Pesho";

            var mockedResource = new Mock<IResources>();
            mockedResource.Setup(x => x.GoldCoins).Returns(5);
            mockedResource.Setup(x => x.SilverCoins).Returns(5);
            mockedResource.Setup(x => x.BronzeCoins).Returns(5);
            
            var mockedStation = new Mock<ITeleportStation>();
            mockedStation.Setup(x => x.PayProfits(It.IsAny<IBusinessOwner>())).Returns(mockedResource.Object);

            var mockedStationsList = new List<ITeleportStation>() { mockedStation.Object };

            var owner = new BusinessOwner(idNumber, nickName, mockedStationsList);

            // act
            owner.CollectProfits();

            // assert
            Assert.AreEqual(5, owner.Resources.GoldCoins);
            Assert.AreEqual(5, owner.Resources.SilverCoins);
            Assert.AreEqual(5, owner.Resources.BronzeCoins);

        }
    }
}
