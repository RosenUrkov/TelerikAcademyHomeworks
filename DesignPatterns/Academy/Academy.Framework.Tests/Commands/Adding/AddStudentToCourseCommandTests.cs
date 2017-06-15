using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Academy.Framework.Models.Contracts;
using Academy.Framework.Core.Contracts;
using Academy.Models.Contracts;
using Academy.Commands.Adding;
using System;

namespace Academy.Tests.Commands.Adding
{
    [TestFixture]
    public class AddStudentToCourseCommandTests
    {
        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldCallAcademyGetStudentMethod()
        {
            // arrange
            var studentMock = new Mock<IStudent>();
            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses[0]).Returns(courseMock.Object);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetStudent(It.IsAny<string>())).Returns(studentMock.Object);
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseFormMock = new Mock<ICourseForm>();
            courseFormMock.Setup(x => x.CheckForm(It.IsAny<string>())).Returns(true);
            courseFormMock.Setup(x => x.AddStudentToCourseForm(It.IsAny<ICourse>(), It.IsAny<IStudent>()));

            var courseForms = new List<ICourseForm>() { courseFormMock.Object };

            var parameters = new List<string>() { "username", "0", "0", "online" };

            var command = new AddStudentToCourseCommand(academyMock.Object, courseForms);

            // act
            command.Execute(parameters);

            // assert
            academyMock.Verify(x => x.GetStudent(It.Is<string>(y => y == "username")), Times.Once);
        }

        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldCallAcademyGetSeasonMethod()
        {
            // arrange
            var studentMock = new Mock<IStudent>();
            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses[0]).Returns(courseMock.Object);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetStudent(It.IsAny<string>())).Returns(studentMock.Object);
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseFormMock = new Mock<ICourseForm>();
            courseFormMock.Setup(x => x.CheckForm(It.IsAny<string>())).Returns(true);
            courseFormMock.Setup(x => x.AddStudentToCourseForm(It.IsAny<ICourse>(), It.IsAny<IStudent>()));

            var courseForms = new List<ICourseForm>() { courseFormMock.Object };

            var parameters = new List<string>() { "username", "0", "0", "online" };

            var command = new AddStudentToCourseCommand(academyMock.Object, courseForms);

            // act
            command.Execute(parameters);

            // assert
            academyMock.Verify(x => x.GetSeason(It.Is<int>(y => y == 0)), Times.Once);
        }

        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldCallCourseFormCheckFormMethod()
        {
            // arrange
            var studentMock = new Mock<IStudent>();
            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses[0]).Returns(courseMock.Object);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetStudent(It.IsAny<string>())).Returns(studentMock.Object);
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseFormMock = new Mock<ICourseForm>();
            courseFormMock.Setup(x => x.CheckForm(It.IsAny<string>())).Returns(true);
            courseFormMock.Setup(x => x.AddStudentToCourseForm(It.IsAny<ICourse>(), It.IsAny<IStudent>()));

            var courseForms = new List<ICourseForm>() { courseFormMock.Object };

            var parameters = new List<string>() { "username", "0", "0", "online" };

            var command = new AddStudentToCourseCommand(academyMock.Object, courseForms);

            // act
            command.Execute(parameters);

            // assert
            courseFormMock.Verify(x => x.CheckForm(It.Is<string>(y => y == "online")), Times.Once);
        }

        [Test]
        public void Execute_WhenThereIsNoSuchCourseForm_ShouldThrowArgumentException()
        {
            // arrange
            var studentMock = new Mock<IStudent>();
            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses[0]).Returns(courseMock.Object);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetStudent(It.IsAny<string>())).Returns(studentMock.Object);
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseFormMock = new Mock<ICourseForm>();
            courseFormMock.Setup(x => x.CheckForm(It.IsAny<string>())).Returns(false);
            courseFormMock.Setup(x => x.AddStudentToCourseForm(It.IsAny<ICourse>(), It.IsAny<IStudent>()));

            var courseForms = new List<ICourseForm>() { courseFormMock.Object };

            var parameters = new List<string>() { "username", "0", "0", "online" };

            var command = new AddStudentToCourseCommand(academyMock.Object, courseForms);

            // act & assert
            Assert.That(() => command.Execute(parameters), Throws.ArgumentException.With.Message.Contains("Invalid course form"));
        }

        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldCallCourseFormAddStudentToCourseMethod()
        {
            // arrange
            var studentMock = new Mock<IStudent>();
            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses[0]).Returns(courseMock.Object);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetStudent(It.IsAny<string>())).Returns(studentMock.Object);
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseFormMock = new Mock<ICourseForm>();
            courseFormMock.Setup(x => x.CheckForm(It.IsAny<string>())).Returns(true);
            courseFormMock.Setup(x => x.AddStudentToCourseForm(It.IsAny<ICourse>(), It.IsAny<IStudent>()));

            var courseForms = new List<ICourseForm>() { courseFormMock.Object };

            var parameters = new List<string>() { "username", "0", "0", "online" };

            var command = new AddStudentToCourseCommand(academyMock.Object, courseForms);

            // act
            command.Execute(parameters);

            // assert
            courseFormMock.Verify(x => x.AddStudentToCourseForm(
                It.Is<ICourse>(y => y == courseMock.Object),
                It.Is<IStudent>(y => y == studentMock.Object)),
            Times.Once);
        }

        [Test]
        public void Execute_WhenPassedParametersAreCorrect_ShouldReturnCorrectMessage()
        {
            // arrange
            var message = "was added to Course";

            var studentMock = new Mock<IStudent>();
            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Courses[0]).Returns(courseMock.Object);

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetStudent(It.IsAny<string>())).Returns(studentMock.Object);
            academyMock.Setup(x => x.GetSeason(It.IsAny<int>())).Returns(seasonMock.Object);

            var courseFormMock = new Mock<ICourseForm>();
            courseFormMock.Setup(x => x.CheckForm(It.IsAny<string>())).Returns(true);
            courseFormMock.Setup(x => x.AddStudentToCourseForm(It.IsAny<ICourse>(), It.IsAny<IStudent>()));

            var courseForms = new List<ICourseForm>() { courseFormMock.Object };

            var parameters = new List<string>() { "username", "0", "0", "online" };

            var command = new AddStudentToCourseCommand(academyMock.Object, courseForms);

            // act
            var result = command.Execute(parameters);

            // assert
            StringAssert.Contains(message, result);
        }
    }
}
