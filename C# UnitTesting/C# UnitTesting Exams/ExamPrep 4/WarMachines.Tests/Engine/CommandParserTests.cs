namespace WarMachines.Tests.Engine
{
    using NUnit.Framework;
    using Moq;
    using Interfaces;
    using Mocks;
    using System.Collections.Generic;

    [TestFixture]
    public class CommandParserTests
    {
        [Test]
        public void Constructor_ShouldSetReaderCorrectly()
        {
            var reader = new Mock<IReader>();

            var parser = new CommandParserMock(reader.Object);

            Assert.AreSame(reader.Object, parser.Reader);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ReadCommands_WhenReadLineReturnsNull_ShouldReturnEmptyListOfICommands(string command)
        {
            var reader = new Mock<IReader>();
            reader.Setup(x => x.ReadLine()).Returns(command);

            var parser = new CommandParserMock(reader.Object);

            var commands = parser.ReadCommands();

            Assert.IsInstanceOf<List<ICommand>>(commands);
        }
    }
}
