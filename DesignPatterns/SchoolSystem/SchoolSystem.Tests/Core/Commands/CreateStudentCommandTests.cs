using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldCallStudentFactoryCreateStudentMethod()
        {
            // arrange 
            var studentMock = new Mock<IStudent>();

            var factoryMock = new Mock<IStudentFactory>();
            factoryMock.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentMock.Object);

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.AddStudent(It.IsAny<int>(), It.IsAny<IStudent>()));

            var parameters = new List<string>() { "firstName", "lastName", "5" };

            var command = new CreateStudentCommand(factoryMock.Object, schoolMock.Object);

            // act
            command.Execute(parameters);

            // assert
            factoryMock.Verify(x => x.CreateStudent(
                It.Is<string>(y=>y=="firstName"),
                It.Is<string>(y=>y=="lastName"),
                It.Is<Grade>(y=>y== Grade.Fifth)),
                Times.Once);
        }

        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldCallSchoolAddStudentMethod()
        {
            // arrange 
            var studentMock = new Mock<IStudent>();

            var factoryMock = new Mock<IStudentFactory>();
            factoryMock.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentMock.Object);

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.AddStudent(It.IsAny<int>(), It.IsAny<IStudent>()));

            var parameters = new List<string>() { "firstName", "lastName", "5" };

            var command = new CreateStudentCommand(factoryMock.Object, schoolMock.Object);

            // act
            command.Execute(parameters);

            // assert
            schoolMock.Verify(x => x.AddStudent(It.Is<int>(y => y == 0), It.Is<IStudent>(y => y == studentMock.Object)));
        }

        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldReturnCorrectMessage()
        {
            // arrange 
            var message = "new student";

            var studentMock = new Mock<IStudent>();

            var factoryMock = new Mock<IStudentFactory>();
            factoryMock.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentMock.Object);

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.AddStudent(It.IsAny<int>(), It.IsAny<IStudent>()));

            var parameters = new List<string>() { "firstName", "lastName", "5" };

            var command = new CreateStudentCommand(factoryMock.Object, schoolMock.Object);

            // act
            var result = command.Execute(parameters);

            // assert
            StringAssert.Contains(message, result);
        }
    }
}
