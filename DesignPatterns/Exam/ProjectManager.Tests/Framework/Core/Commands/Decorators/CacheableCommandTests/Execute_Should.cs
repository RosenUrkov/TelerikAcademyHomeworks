using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Services;
using ProjectManager.Framework.Core.Commands.Decorators;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CallCommandExecuteMethod_WhenCacheIsExpired()
        {
            // arrange
            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(true);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns("execution result");

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            commandMock.Verify(x => x.Execute(It.Is<IList<string>>(y => y == parameters)), Times.Once);
        }

        [Test]
        public void CallResetCacheMethod_WhenCacheIsExpired()
        {
            // arrange
            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(true);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns("execution result");

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            serviceMock.Verify(x => x.ResetCache(), Times.Once);
        }

        [Test]
        public void CallAddCacheValueMethod_WhenCacheIsExpired()
        {
            // arrange
            var methodName = "Execute";
            var result = "execution result";

            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(true);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(result);

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            serviceMock.Verify(x => x.AddCacheValue(It.IsAny<string>(), It.Is<string>(y => y == methodName), It.Is<string>(y => y == result)), Times.Once);
        }

        [Test]
        public void CallGetCacheValue_WhenCacheIsExpired()
        {
            // arrange
            var methodName = "Execute";
            var result = "execution result";

            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(true);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(result);

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            serviceMock.Verify(x => x.GetCacheValue(It.IsAny<string>(), It.Is<string>(y=>y==methodName)),Times.Once);
        }

        [Test]
        public void CallGetCacheValue_WhenCacheIsNotExpired()
        {
            // arrange
            var methodName = "Execute";
            var result = "execution result";

            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(false);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(result);

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            serviceMock.Verify(x => x.GetCacheValue(It.IsAny<string>(), It.Is<string>(y => y == methodName)), Times.Once);
        }

        [Test]
        public void NotCallPassedCommandExecuteMethod_WhenCacheIsNotExpired()
        {
            // arrange
            var result = "execution result";

            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(false);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(result);

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            commandMock.Verify(x => x.Execute(It.Is<IList<string>>(y => y == parameters)), Times.Never);
        }

        [Test]
        public void NotCallResetCacheMethod_WhenCacheIsNotExpired()
        {
            // arrange
            var result = "execution result";

            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(false);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(result);

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            serviceMock.Verify(x => x.ResetCache(), Times.Never);
        }

        [Test]
        public void NotCallAddCacheValueMethod_WhenCacheIsNotExpired()
        {
            // arrange
            var methodName = "Execute";
            var result = "execution result";

            var serviceMock = new Mock<ICachingService>();
            serviceMock.Setup(x => x.IsExpired).Returns(false);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(result);

            var parameters = new List<string>();

            var command = new CacheableCommand(commandMock.Object, serviceMock.Object);

            // act
            command.Execute(parameters);

            // assert
            serviceMock.Verify(x => x.AddCacheValue(It.IsAny<string>(), It.Is<string>(y => y == methodName), It.Is<string>(y => y == result)), Times.Never);

        }
    }
}
