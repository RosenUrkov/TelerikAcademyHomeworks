using NUnit.Framework;
using Moq;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands;

namespace SchoolSystem.Tests.Core.Commands
{
    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldCallSchoolGetStudentMethod()
        {
            // arrange
            var studentMock = new Mock<IStudent>();

            var teacherMock = new Mock<ITeacher>();
            teacherMock.Setup(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<float>()));

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);
            schoolMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(teacherMock.Object);
            
            var parameters = new List<string>() { "3", "4", "5" };

            var command = new TeacherAddMarkCommand(schoolMock.Object);

            // act
            command.Execute(parameters);

            // assert
            schoolMock.Verify(x => x.GetStudent(It.Is<int>(y => y == 4)), Times.Once);
        }

        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldCallSchoolGetTeacherMethod()
        {
            // arrange
            var studentMock = new Mock<IStudent>();

            var teacherMock = new Mock<ITeacher>();
            teacherMock.Setup(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<float>()));

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);
            schoolMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(teacherMock.Object);

            var parameters = new List<string>() { "3", "4", "5" };

            var command = new TeacherAddMarkCommand(schoolMock.Object);

            // act
            command.Execute(parameters);

            // assert
            schoolMock.Verify(x => x.GetTeacher(It.Is<int>(y => y == 3)), Times.Once);
        }

        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldTeacherAddMarkMethod()
        {
            // arrange
            var studentMock = new Mock<IStudent>();

            var teacherMock = new Mock<ITeacher>();
            teacherMock.Setup(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<float>()));

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);
            schoolMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(teacherMock.Object);

            var parameters = new List<string>() { "3", "4", "5" };

            var command = new TeacherAddMarkCommand(schoolMock.Object);

            // act
            command.Execute(parameters);

            // assert
            teacherMock.Verify(x => x.AddMark(It.Is<IStudent>(y => y == studentMock.Object), It.Is<float>(y => y == 5)),Times.Once);
        }

        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldReturnCorrectMessage()
        {
            // arrange
            var message = "added mark";

            var studentMock = new Mock<IStudent>();

            var teacherMock = new Mock<ITeacher>();
            teacherMock.Setup(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<float>()));

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);
            schoolMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(teacherMock.Object);

            var parameters = new List<string>() { "3", "4", "5" };

            var command = new TeacherAddMarkCommand(schoolMock.Object);

            // act
            var result = command.Execute(parameters);

            // assert
            StringAssert.Contains(message, result);
        }
    }
}
