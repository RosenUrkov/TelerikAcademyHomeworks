namespace WarMachines.Tests.Engine
{
    using NUnit.Framework;
    using Moq;
    using WarMachines.Engine;
    using Interfaces;

    [TestFixture]
   public class MachineFactoryTests
    {
        [Test]
        public void HirePilot_WhenNameIsValid_ShouldReturnNewPilot()
        {
            // arrange
            var factory = new MachineFactory();

            // act
            var pilot = factory.HirePilot("validName");

            // assert
            Assert.IsInstanceOf<IPilot>(pilot);
        }

        [TestCase(null)]
        [TestCase("")]
        public void HirePilot_WhenNameIsNullOrEmptyValid_ShouldThrowArgumentNullExceptionWithCorrectMessage(string name)
        {
            // arrange
            var factory = new MachineFactory();

            // act & assert
            Assert.That(() => factory.HirePilot(name), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }


    }
}
