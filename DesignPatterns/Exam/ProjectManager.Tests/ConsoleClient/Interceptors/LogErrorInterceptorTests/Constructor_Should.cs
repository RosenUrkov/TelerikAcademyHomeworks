using NUnit.Framework;
using Moq;
using ProjectManager.Framework.Core.Common.Contracts;
using System;
using ProjectManager.ConsoleClient.Interceptors;

namespace ProjectManager.Tests.ConsoleClient.Interceptors.LogErrorInterceptorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_WhenPassedLoggerIsNull()
        {
            // arrange
            var writerMock = new Mock<IWriter>();

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(null, writerMock.Object));
        }

        [Test]
        public void Throw_WhenPassedWriterIsNull()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(loggerMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenPassedParametersAreCorrect()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            
            // act & assert
            Assert.DoesNotThrow(() => new LogErrorInterceptor(loggerMock.Object, writerMock.Object));
        }
    }
}
