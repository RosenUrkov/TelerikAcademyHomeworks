using NUnit.Framework;
using Moq;
using ProjectManager.Framework.Services;
using System;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class AddCacheValue_Should
    {
        [Test]
        public void AddThePassedValueCorrectly()
        {
            // arrange
            var span = new TimeSpan(20);

            var date = new DateTime(2017, 6, 15, 19, 37, 15);
            var dateServiceMock = new Mock<IDateService>();
            dateServiceMock.Setup(x => x.Now).Returns(date);

            var service = new CachingService(span, dateServiceMock.Object);

            // act
           service.AddCacheValue("class name", "method name", "value");

            // assert
            var result = service.GetCacheValue("class name", "method name");
            Assert.AreEqual("value", result);
        }
    }
}
