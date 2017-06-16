using NUnit.Framework;
using Moq;
using ProjectManager.Framework.Services;
using System;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Commands.Contracts;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_WhenThePassedCommandIsNull()
        {
            // arrange
            var serviceMock = new Mock<ICachingService>();

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(null, serviceMock.Object));
        }

        [Test]
        public void Throw_WhenThePassedServiceIsNull()
        {
            // arrange
            var commandMock = new Mock<ICommand>();

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(commandMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenThePassedParametersAreCorrect()
        {
            // arrange
            var serviceMock = new Mock<ICachingService>();
            var commandMock = new Mock<ICommand>();

            // act & assert
            Assert.DoesNotThrow(() => new CacheableCommand(commandMock.Object, serviceMock.Object));
        }
    }
}
