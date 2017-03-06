namespace IntergalacticTravel.Tests
{
    using NUnit.Framework;
    using Moq;
    using Contracts;
    using Mocks;
    using System.Collections.Generic;
    using Exceptions;

    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenATeleportStationIsCreatedWithValidParameters_ShouldSetUpAllProvidedFields()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();

            var mockedPath = new Mock<IPath>();
            var mockedMap = new List<IPath>() { mockedPath.Object };

            // act
            var station = new TeleportationStationMocked(mockedOwner.Object,mockedMap,mockedLocation.Object);

            // assert
            Assert.AreSame(mockedOwner.Object, station.Owner);
            Assert.AreSame(mockedLocation.Object, station.Location);
            Assert.AreSame(mockedMap, station.GalacticMap);
        }

        [Test]
        public void Constructor_WhenATeleportStationIsCreatedWithValidParameters_ShouldInitializeResources()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();

            var mockedPath = new Mock<IPath>();
            var mockedMap = new List<IPath>() { mockedPath.Object };

            // act
            var station = new TeleportationStationMocked(mockedOwner.Object, mockedMap, mockedLocation.Object);

            // assert
            Assert.IsNotNull(station.Resources);
        }

        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedStationLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);

            var mockedTeleportLocation = new Mock<ILocation>();

            // act & assert
            Assert.That(() => station.TeleportUnit(null, mockedTeleportLocation.Object), 
                Throws.ArgumentNullException.With.Message.Contains("unitToTeleport"));           
            
        }

        [Test]
        public void TeleportUnit_WhenTeleportLocationIsNull_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedStationLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);

            var mockedUnit = new Mock<IUnit>();

            // act & assert
            Assert.That(() => station.TeleportUnit(mockedUnit.Object, null),
                Throws.ArgumentNullException.With.Message.Contains("destination"));

        }

        [Test]
        public void TeleportUnit_WnenUnitIsTryingToTeleportFromDistantLocation_ShoultThrowTeleportOutOfRangeExceptionWithValidMessage()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            
            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");

            var mockedPath = new Mock<IPath>();
            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation).Returns(mockedTeleportLocation.Object);

            // act & assert
            Assert.That(() => station.TeleportUnit(mockedUnit.Object,mockedTeleportLocation.Object ),
                Throws.TypeOf<TeleportOutOfRangeException>().With.Message.Contains("unitToTeleport.CurrentLocation"));
        }

        [Test]
        public void TeleportUnit_WnenUnitIsTryingToTeleportToANonListedGalaxy_ShoultThrowLocationNotFoundExceptionWithValidMessage()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");

            var mockedGalaxyMap = new List<IPath>();

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation).Returns(mockedStationLocation.Object);

            // act & assert
            Assert.That(() => station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object),
                Throws.TypeOf<LocationNotFoundException>().With.Message.Contains("Galaxy"));
        }

        [Test]
        public void TeleportUnit_WnenUnitIsTryingToTeleportToANonListedPlanetInTheGalaxy_ShoultThrowLocationNotFoundExceptionWithValidMessage()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");

            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object};

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x =>x.Planet.Name).Returns("NotPlanetName");

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation).Returns(mockedStationLocation.Object);

            // act & assert
            Assert.That(() => station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object),
                Throws.TypeOf<LocationNotFoundException>().With.Message.Contains("Planet"));
        }

        [Test]
        public void TeleportUnit_WnenUnitIsTryingToTeleportToALocationOfAnotherUnit_ShoultThrowInvalidTeleportationExceptionWithValidMessage()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");
            mockedTeleportLocation.Setup(x => x.Coordinates.Latitude).Returns(4.2);
            mockedTeleportLocation.Setup(x => x.Coordinates.Longtitude).Returns(2.4);

            var anotherMockedUnit = new Mock<IUnit>();
            anotherMockedUnit.Setup(x => x.CurrentLocation).Returns(mockedTeleportLocation.Object);

            var mockedUnitCollection = new List<IUnit>() { anotherMockedUnit.Object};

            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            mockedPath.Setup(x => x.TargetLocation.Planet.Units).Returns(mockedUnitCollection);
            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);            

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation).Returns(mockedStationLocation.Object);

            // act & assert
            Assert.That(() => station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object),
                Throws.TypeOf<InvalidTeleportationLocationException>().With.Message.Contains("units will overlap"));
        }

        [Test]
        public void TeleportUnit_WnenUnitIsTryingToTeleportCorrectlyButSurviceCostMoreThanHisResources_ShoultThrowInsufficientResourcesExceptionWithValidMessage()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");
            
            var mockedUnitCollection = new List<IUnit>();
                        
            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            mockedPath.Setup(x => x.TargetLocation.Planet.Units).Returns(mockedUnitCollection);
            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);
            
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation).Returns(mockedStationLocation.Object);
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);

            // act & assert
            Assert.That(() => station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object),
                Throws.TypeOf<InsufficientResourcesException>().With.Message.Contains("FREE LUNCH"));
        }

        [Test]
        public void TeleportUnit_WnenTeleportIsSuccesfull_ShouldRequireAPaymentFromUnitToTeleport()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedStationLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");

            var mockedResources = new Mock<IResources>();
            mockedResources.Setup(x => x.GoldCoins).Returns(5);
            mockedResources.Setup(x => x.SilverCoins).Returns(5);
            mockedResources.Setup(x => x.BronzeCoins).Returns(5);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedStationLocation.Object);
            mockedUnit.SetupSet(x => x.CurrentLocation= It.IsAny<ILocation>());
            mockedUnit.Setup(x => x.PreviousLocation);
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResources.Object);

            var mockedUnitCollection = new List<IUnit>();

            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            mockedPath.Setup(x => x.TargetLocation.Planet.Units).Returns(mockedUnitCollection);
            mockedPath.Setup(x => x.Cost).Returns(mockedResources.Object);           

            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);           
            

            // act
            station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object);

            // assert
            Assert.AreEqual(5,station.Resources.GoldCoins);
            Assert.AreEqual(5,station.Resources.SilverCoins);
            Assert.AreEqual(5,station.Resources.BronzeCoins);

        }

        [Test]
        public void TeleportUnit_WnenTeleportIsSuccesfull_ShouldChangeTheUnitsPrevousLocation()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedStationLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");

            var mockedResources = new Mock<IResources>();
            mockedResources.Setup(x => x.GoldCoins).Returns(5);
            mockedResources.Setup(x => x.SilverCoins).Returns(5);
            mockedResources.Setup(x => x.BronzeCoins).Returns(5);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedStationLocation.Object);
            mockedUnit.SetupSet(x => x.CurrentLocation = It.IsAny<ILocation>());
            mockedUnit.SetupSet(x => x.PreviousLocation = It.Is<ILocation>(y => y == mockedStationLocation.Object));
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResources.Object);

            var mockedUnitCollection = new List<IUnit>();

            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            mockedPath.Setup(x => x.TargetLocation.Planet.Units).Returns(mockedUnitCollection);
            mockedPath.Setup(x => x.Cost).Returns(mockedResources.Object);

            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);


            // act
            station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object);

            // assert
            mockedUnit.VerifySet(x=>x.PreviousLocation = It.Is<ILocation>(y => y == mockedStationLocation.Object), Times.Once);
        }

        [Test]
        public void TeleportUnit_WnenTeleportIsSuccesfull_ShouldChangeTheUnitsCurrentLocation()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedStationLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");

            var mockedResources = new Mock<IResources>();
            mockedResources.Setup(x => x.GoldCoins).Returns(5);
            mockedResources.Setup(x => x.SilverCoins).Returns(5);
            mockedResources.Setup(x => x.BronzeCoins).Returns(5);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedStationLocation.Object);
            mockedUnit.SetupSet(x => x.CurrentLocation = It.Is<ILocation>(y=>y==mockedTeleportLocation.Object));
            mockedUnit.SetupSet(x => x.PreviousLocation = It.IsAny<ILocation>());
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResources.Object);

            var mockedUnitCollection = new List<IUnit>();

            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            mockedPath.Setup(x => x.TargetLocation.Planet.Units).Returns(mockedUnitCollection);
            mockedPath.Setup(x => x.Cost).Returns(mockedResources.Object);

            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);


            // act
            station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object);

            // assert
            mockedUnit.VerifySet(x => x.CurrentLocation = It.Is<ILocation>(y=>y==mockedTeleportLocation.Object), Times.Once);
        }

        [Test]
        public void TeleportUnit_WnenTeleportIsSuccesfull_ShouldAddTheUnitToTheListOfUnitsOfTheCurrentLocation()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedStationLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");

            var mockedResources = new Mock<IResources>();
            mockedResources.Setup(x => x.GoldCoins).Returns(5);
            mockedResources.Setup(x => x.SilverCoins).Returns(5);
            mockedResources.Setup(x => x.BronzeCoins).Returns(5);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedStationLocation.Object);
            mockedUnit.SetupSet(x => x.CurrentLocation = It.Is<ILocation>(y=>y==mockedTeleportLocation.Object));
            mockedUnit.SetupSet(x => x.PreviousLocation = It.Is<ILocation>(y=>y==mockedStationLocation.Object));
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResources.Object);

            var mockedUnitCollection = new List<IUnit>();

            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            mockedPath.Setup(x => x.TargetLocation.Planet.Units).Returns(mockedUnitCollection);
            mockedPath.Setup(x => x.Cost).Returns(mockedResources.Object);

            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);


            // act
            station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object);

            // assert
            Assert.IsTrue(mockedUnitCollection.Contains(mockedUnit.Object));
        }

        [Test]
        public void TeleportUnit_WnenTeleportIsSuccesfull_ShouldRemoveTheUnitFromTheListOfUnitsOfHisPrevousLocation()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();

            var mockedStationLocation = new Mock<ILocation>();
            mockedStationLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");
            mockedStationLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedStationLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));

            var mockedTeleportLocation = new Mock<ILocation>();
            mockedTeleportLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Andromeda");
            mockedTeleportLocation.Setup(x => x.Planet.Name).Returns("PlanetName");

            var mockedResources = new Mock<IResources>();
            mockedResources.Setup(x => x.GoldCoins).Returns(5);
            mockedResources.Setup(x => x.SilverCoins).Returns(5);
            mockedResources.Setup(x => x.BronzeCoins).Returns(5);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedStationLocation.Object);
            mockedUnit.SetupSet(x => x.CurrentLocation = It.Is<ILocation>(y => y == mockedTeleportLocation.Object));
            mockedUnit.SetupSet(x => x.PreviousLocation = It.Is<ILocation>(y => y == mockedStationLocation.Object));
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedResources.Object);

            var mockedUnitCollection = new List<IUnit>();

            var mockedPath = new Mock<IPath>();
            mockedPath.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            mockedPath.Setup(x => x.TargetLocation.Planet.Name).Returns("PlanetName");
            mockedPath.Setup(x => x.TargetLocation.Planet.Units).Returns(mockedUnitCollection);
            mockedPath.Setup(x => x.Cost).Returns(mockedResources.Object);

            var mockedGalaxyMap = new List<IPath>() { mockedPath.Object };

            var station = new TeleportationStationMocked(mockedOwner.Object, mockedGalaxyMap, mockedStationLocation.Object);


            // act
            station.TeleportUnit(mockedUnit.Object, mockedTeleportLocation.Object);

            // assert
            mockedStationLocation.Verify(x => x.Planet.Units.Remove(It.IsAny<IUnit>()),Times.Once);

        }

        [Test]
        public void PayProfits_WnenTheArgumentRepresentsTheOwner_ShouldReturnTheTotalAmountOfProfits()
        {
            // arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            mockedOwner.Setup(x => x.IdentificationNumber).Returns(5);

            var mockedLocation = new Mock<ILocation>();

            var mockedPath = new Mock<IPath>();
            var mockedMap = new List<IPath>() { mockedPath.Object };
            
            var station = new TeleportationStationMocked(mockedOwner.Object, mockedMap, mockedLocation.Object);

            station.Resources.GoldCoins = 5;
            station.Resources.SilverCoins = 5;
            station.Resources.BronzeCoins = 5;

            // act
            var payment = station.PayProfits(mockedOwner.Object);

            // assert
            Assert.AreEqual(payment.GoldCoins,5);
            Assert.AreEqual(payment.SilverCoins,5);
            Assert.AreEqual(payment.BronzeCoins, 5);
        }
    }
}
