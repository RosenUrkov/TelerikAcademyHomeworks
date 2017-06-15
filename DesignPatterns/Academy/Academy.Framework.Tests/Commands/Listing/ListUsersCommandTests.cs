using NUnit.Framework;
using Moq;
using Academy.Framework.Models.Contracts;
using System.Collections.Generic;
using Academy.Models;
using Academy.Commands.Listing;

namespace Academy.Tests.Commands.Listing
{
    [TestFixture]
    public class ListUsersCommandTests
    {
        [Test]
        public void Exectute_WhenPassedParametersAreCorrect_ShouldCallAcademyGetUsersMethod()
        {
            // arrange
            var users = new List<IUser>();

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetUsers()).Returns(users);

            var command = new ListUsersCommand(academyMock.Object);

            var parameters = new List<string>();

            // act
            command.Execute(parameters);

            // assert
            academyMock.Verify(x => x.GetUsers(), Times.Once);
        }

        [Test]
        public void Exectute_WhenThereAreNoUsers_ShouldReturnCorrectMessage()
        {
            // arrange
            var message = "There are no registered users!";
            
            var users = new List<IUser>();

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetUsers()).Returns(users);

            var command = new ListUsersCommand(academyMock.Object);

            var parameters = new List<string>();

            // act
            var result = command.Execute(parameters);

            // assert
            StringAssert.StartsWith(message, result);
        }

        [Test]
        public void Exectute_WhenThereIsUser_ShouldCallUserToStringMethod()
        {
            // arrange
            var message = "string user";

            var userMock = new Mock<IUser>();
            userMock.Setup(x => x.ToString()).Returns(message);

            var users = new List<IUser>() { userMock.Object};

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetUsers()).Returns(users);

            var command = new ListUsersCommand(academyMock.Object);

            var parameters = new List<string>();

            // act
            var result = command.Execute(parameters);

            // assert
            userMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void Exectute_WhenThereIsUser_ShouldReturnCorrectMessage()
        {
            // arrange
            var message = "string user";

            var userMock = new Mock<IUser>();
            userMock.Setup(x => x.ToString()).Returns(message);

            var users = new List<IUser>() { userMock.Object };

            var academyMock = new Mock<IAcademyModel>();
            academyMock.Setup(x => x.GetUsers()).Returns(users);

            var command = new ListUsersCommand(academyMock.Object);

            var parameters = new List<string>();

            // act
            var result = command.Execute(parameters);

            // assert
            StringAssert.StartsWith(message, result);
        }
    }
}
