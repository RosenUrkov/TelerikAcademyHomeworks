namespace IntergalacticTravel.Tests
{
    using Exceptions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class UnitsFactoryTest
    {
        [Test]
        public void GetUnit_WhenAValidCommandThatIndicatesCreatingProcyon_ShouldReturnNewProcyon()
        {
            // arrange
            var factory = new UnitsFactory();
            string validCommand = "create unit Procyon Gosho 1";

            // act
            var unit = factory.GetUnit(validCommand);

            // assert
            Assert.IsInstanceOf<Procyon>(unit);
        }

        [Test]
        public void GetUnit_WhenAValidCommandThatIndicatesCreatingLuyten_ShouldReturnNewLuyten()
        {
            // arrange
            var factory = new UnitsFactory();
            string validCommand = "create unit Luyten Gosho 1";

            // act
            var unit = factory.GetUnit(validCommand);

            // assert
            Assert.IsInstanceOf<Luyten>(unit);
        }

        [Test]
        public void GetUnit_WhenAValidCommandThatIndicatesCreatingLacaille_ShouldReturnNewLacaille()
        {
            // arrange
            var factory = new UnitsFactory();
            string validCommand = "create unit Lacaille Gosho 1";

            // act
            var unit = factory.GetUnit(validCommand);

            // assert
            Assert.IsInstanceOf<Lacaille>(unit);
        }

        [TestCase("create unit Luyten Pesho")]
        [TestCase("create Luyten Pesho 2")]
        [TestCase("create unit Luen Pesho")]
        public void GetUnit_WhenCommandIsInvalid_ShouldThrowInvalidUnitCreationCommandException(string command)
        {
            // arrange
            var factory = new UnitsFactory();

            // act and assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }
    }
}
