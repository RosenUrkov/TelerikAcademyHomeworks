using NUnit.Framework;
using Moq;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class ParameterCount_Should
    {
        [Test]
        public void ReturnThePassedCommandParametersCount()
        {
            // arrange
            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.ParameterCount).Returns(7);

            var serviceMock = new Mock<ICachingService>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            var result = command.ParameterCount;

            // assert
            Assert.AreEqual(7, result);
        }
    }
}
