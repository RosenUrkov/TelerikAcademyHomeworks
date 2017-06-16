using NUnit.Framework;
using Moq;
using System;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_WhenTimespanIsLessThanZero()
        {
            // arrange
            var span = new TimeSpan(-1);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.Setup(x => x.Now).Returns(date);

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingService(span, dateServiceMock.Object));
        }

        [Test]
        public void Throw_DateServiceIsNull()
        {
            // arrange
            var span = new TimeSpan(20);
            
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new CachingService(span, null));
        }

        [Test]
        public void NotThrow_WhenPassedParametersAreCorrect()
        {
            // arrange
            var span = new TimeSpan(20);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.Setup(x => x.Now).Returns(date);

            // act & assert
            Assert.DoesNotThrow(() => new CachingService(span, dateServiceMock.Object));
        }

        [Test]
        public void CallDateServiceNowProperty_WhenPassedParametersAreCorrect()
        {
            // arrange
            var span = new TimeSpan(20);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.Setup(x => x.Now).Returns(date);

            // act
            var service = new CachingService(span, dateServiceMock.Object);
            
            // assert
            dateServiceMock.Verify(x => x.Now, Times.Exactly(1));
        }
    }
}
