using NUnit.Framework;
using Moq;
using ProjectManager.Framework.Services;
using System;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class IsExpired_Should
    {
        [Test]
        public void ReturnTrue_WhenTheNewDateIsBiggerThatTheExpirationDate()
        {
            // arrange
            var span = new TimeSpan(20);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var biggerDate = new DateTime(2017, 6, 15, 21, 37, 15);

            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.SetupSequence(x => x.Now).Returns(date).Returns(biggerDate);

            var service = new CachingService(span, dateServiceMock.Object);

            // act
            var result = service.IsExpired;

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenTheNewDateIsSmallerThatTheExpirationDate()
        {
            // arrange
            var span = new TimeSpan(20);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var smallerDate = new DateTime(2017, 6, 15, 17, 37, 15);

            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.SetupSequence(x => x.Now).Returns(date).Returns(smallerDate);

            var service = new CachingService(span, dateServiceMock.Object);

            // act
            var result = service.IsExpired;

            // assert
            Assert.IsFalse(result);
        }
    }
}
