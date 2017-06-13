using NUnit.Framework;
using Moq;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands;

namespace SchoolSystem.Tests.Core.Commands
{
    [TestFixture]
    public class RemoveStudentCommandTests
    {
        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldCallSchoolRemoveStudentMethod()
        {
            // arrange
            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.RemoveStudent(It.IsAny<int>()));

            var parameters = new List<string>() { "3" };

            var command = new RemoveStudentCommand(schoolMock.Object);

            // act
            command.Execute(parameters);

            // assert
            schoolMock.Verify(x => x.RemoveStudent(It.Is<int>(y => y == 3)),Times.Once);
        }

        [Test]
        public void Execute_WhenCorrectParametsArePassed_ShouldReturnCorrectMessage()
        {
            // arrange
            var message = "sucessfully removed";

            var schoolMock = new Mock<ISchoolSystem>();
            schoolMock.Setup(x => x.RemoveStudent(It.IsAny<int>()));

            var parameters = new List<string>() { "3" };

            var command = new RemoveStudentCommand(schoolMock.Object);

            // act
            var result = command.Execute(parameters);

            // assert
            StringAssert.Contains(message, result);
        }
    }
}
