using NUnit.Framework;
using Moq;
using ProjectManager.Framework.Core.Common.Contracts;
using Ninject.Extensions.Interception;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Exceptions;
using System;

namespace ProjectManager.Tests.ConsoleClient.Interceptors.LogErrorInterceptorTests
{
    [TestFixture]
    public class Intercept_Should
    {
        [Test]
        public void CallInvocationProceedMethod()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();

            var interceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);

            // act
            interceptor.Intercept(invocation.Object);

            // assert
            invocation.Verify(x => x.Proceed(), Times.Once);
        }

        [Test]
        public void NotCallLoggerAndWriter_WhenNoExceptionsAreThrown()
        {
            // arrange
            var message = "message";

            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();

            var interceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);

            // act
            interceptor.Intercept(invocation.Object);

            // assert
            loggerMock.Verify(x => x.Error(It.Is<string>(y => y == message)), Times.Never);
            writerMock.Verify(x => x.WriteLine(It.Is<string>(y => y == message)), Times.Never);
        }

        [Test]
        public void CallLoggerAndWriter_WhenUserValidationExceptionIsThrown()
        {
            // arrange
            var message = "message";

            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();
            invocation.Setup(x => x.Proceed()).Throws(new UserValidationException(message));

            var interceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);

            // act
            interceptor.Intercept(invocation.Object);

            // assert
            loggerMock.Verify(x => x.Error(It.Is<string>(y => y == message)), Times.Once);
            writerMock.Verify(x => x.WriteLine(It.Is<string>(y => y == message)), Times.Once);
        }

        [Test]
        public void CallLoggerAndWriter_WhenUGenericExceptionIsThrown()
        {
            // arrange
            var message = "message";
            var writerMessage = "Opps, something happened. Check the log file :(";

            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();
            invocation.Setup(x => x.Proceed()).Throws(new Exception(message));

            var interceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);

            // act
            interceptor.Intercept(invocation.Object);

            // assert
            loggerMock.Verify(x => x.Error(It.Is<string>(y => y == message)), Times.Once);
            writerMock.Verify(x => x.WriteLine(It.Is<string>(y => y == writerMessage)), Times.Once);
        }
    }
}
