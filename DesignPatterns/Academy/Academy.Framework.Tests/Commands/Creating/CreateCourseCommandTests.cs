using NUnit.Framework;
using Moq;
using Academy.Framework.Models.Contracts;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using System.Collections.Generic;
using Academy.Commands.Creating;

namespace Academy.Tests.Commands.Creating
{
    [TestFixture]
    public class CreateCourseCommandTests
    {
        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldCallAcademyGetSeasonMethod()
        {
            // arrange
            var courses = new List<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses).Returns(courses);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseMock = new Mock<ICourse>();

            var factoryMock = new Mock<IAcademyFactory>();
            factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(courseMock.Object);

            var command = new CreateCourseCommand(academyMock.Object, factoryMock.Object);

            var parameters = new List<string>() { "5", "name", "3", "15/6/2017" };

            // act
            command.Execute(parameters);

            // assert
            academyMock.Verify(x => x.GetSeason(It.Is<int>(y => y == 5)), Times.Once);
        }

        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldCallFactoryCreateCourseMethod()
        {
            // arrange
            var courses = new List<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses).Returns(courses);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseMock = new Mock<ICourse>();

            var factoryMock = new Mock<IAcademyFactory>();
            factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(courseMock.Object);

            var command = new CreateCourseCommand(academyMock.Object, factoryMock.Object);

            var parameters = new List<string>() { "5", "name", "3", "15/6/2017" };

            // act
            command.Execute(parameters);

            // assert
            factoryMock.Verify(x => x.CreateCourse(
                It.Is<string>(y => y == "name"),
                It.Is<string>(y => y == "3"),
                It.Is<string>(y => y == "15/6/2017")),
            Times.Once);
        }

        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldAddCourseToCoursesCollection()
        {
            // arrange
            var courses = new List<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses).Returns(courses);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseMock = new Mock<ICourse>();

            var factoryMock = new Mock<IAcademyFactory>();
            factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(courseMock.Object);

            var command = new CreateCourseCommand(academyMock.Object, factoryMock.Object);

            var parameters = new List<string>() { "5", "name", "3", "15/6/2017" };

            // act
            command.Execute(parameters);

            // assert
            CollectionAssert.Contains(courses, courseMock.Object);
        }

        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldReturnCorrectMessage()
        {
            // arrange
            var message = "Course with ID";

            var courses = new List<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses).Returns(courses);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseMock = new Mock<ICourse>();

            var factoryMock = new Mock<IAcademyFactory>();
            factoryMock.Setup(x => x.CreateCourse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(courseMock.Object);

            var command = new CreateCourseCommand(academyMock.Object, factoryMock.Object);

            var parameters = new List<string>() { "5", "name", "3", "15/6/2017" };

            // act
            var result = command.Execute(parameters);

            // assert
            StringAssert.Contains(message, result);
        }
    }
}
