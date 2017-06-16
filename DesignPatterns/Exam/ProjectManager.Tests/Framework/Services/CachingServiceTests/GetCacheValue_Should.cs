using NUnit.Framework;
using Moq;
using ProjectManager.Framework.Services;
using System;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class GetCacheValue_Should
    {
        [Test]
        public void ReturnTheAddedCacheValue()
        {
            // arrange
            var span = new TimeSpan(20);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.Setup(x => x.Now).Returns(date);

            var service = new CachingService(span, dateServiceMock.Object);
            service.AddCacheValue("class name", "method name", "value");

            // act
            var result = service.GetCacheValue("class name", "method name");

            // assert
            Assert.AreEqual("value", result);
        }
    }
}
