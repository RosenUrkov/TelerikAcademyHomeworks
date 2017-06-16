using NUnit.Framework;
using Moq;
using System;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class ResetCache_Should
    {
        [Test]
        public void CallDateServiceNowPropertyTwice()
        {
            // arrange
            var span = new TimeSpan(20);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.Setup(x => x.Now).Returns(date);

            var service = new CachingService(span, dateServiceMock.Object);

            // act
            service.ResetCache();

            // assert
            dateServiceMock.Verify(x => x.Now, Times.Exactly(2));
        }
    }
}
