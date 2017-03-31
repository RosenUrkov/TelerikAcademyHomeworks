namespace Academy.Tests.Core.Factories
{
    using NUnit.Framework;
    using Moq;
    using Academy.Core.Factories;
    using System;
    using Academy.Models.Utils.LectureResources;

    [TestFixture]
    public class AcademyFactoryTests
    {
        [Test]
        public void CreateLectureResourse_WhenPassedTypeIsInvalid_ShouldThrowArgumentException()
        {
            var factory = AcademyFactory.Instance;
            string type = "canNotBeCorrectType";

            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource(type, "name", "url"));
        }

        [TestCase("video", "VideoResource")]
        [TestCase("demo", "DemoResource")]
        [TestCase("presentation", "PresentationResource")]
        [TestCase("homework", "HomeworkResource")]
        public void CreateLectureResourse_WhenPassedCorrectParameters_ShouldReturnCorrectInstancesWithCorrectlyAssignetData(string type, string className)
        {
            var factory = AcademyFactory.Instance;

            var resource = factory.CreateLectureResource(type, "name", "youarel");

            Assert.AreEqual(className, resource.GetType().Name);
        }
    }
}
