namespace ProjectManager.Tests.Core.Commands
{
    using NUnit.Framework;
    using Moq;
    using Data;
    using Models.Contracts;
    using Common.Contracts;
    using ProjectManager.Core.Commands;
    using System.Collections.Generic;
    using Models;

    [TestFixture]
    public class CreateTaskCommandTests
    {
        [Test]
        public void Execute_WhenEvrythingIsRight_ShouldCallValidatorValidateEmptyParameters()
        {
            // arrange
            var mockedUser = new Mock<IUser>();
            var mockedUsersList = new List<IUser>() { mockedUser.Object };

            var mockedTasksList = new List<ITask>();

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.Users).Returns(mockedUsersList);
            mockedProject.Setup(x => x.Tasks).Returns(mockedTasksList);

            var mockedProjectsList = new List<IProject>() { mockedProject.Object };

            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Projects).Returns(mockedProjectsList);

            var mockedTask = new Mock<ITask>();

            var mockedFactory = new Mock<IModelsFactory>();
            mockedFactory.Setup(x => x.CreateTask(It.IsAny<string>(), It.IsAny<IUser>(), It.IsAny<string>())).Returns(mockedTask.Object);

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateExactIntValue(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()));

            var createTaskCommand = new CreateTaskCommand(mockedDatabase.Object, mockedFactory.Object, mockedValidator.Object);

            string taskName = "validName";
            string taskState = "validState";
            var commandParameters = new List<string>() { "0", "0", taskName, taskState };

            // act
            createTaskCommand.Execute(commandParameters);

            // assert
            mockedValidator.Verify(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Execute_WhenEvrythingIsRight_ShouldCallValidatorValidateExactIntValue()
        {
            // arrange
            var mockedUser = new Mock<IUser>();
            var mockedUsersList = new List<IUser>() { mockedUser.Object };

            var mockedTasksList = new List<ITask>();

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.Users).Returns(mockedUsersList);
            mockedProject.Setup(x => x.Tasks).Returns(mockedTasksList);

            var mockedProjectsList = new List<IProject>() { mockedProject.Object };

            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Projects).Returns(mockedProjectsList);

            var mockedTask = new Mock<ITask>();

            var mockedFactory = new Mock<IModelsFactory>();
            mockedFactory.Setup(x => x.CreateTask(It.IsAny<string>(), It.IsAny<IUser>(), It.IsAny<string>())).Returns(mockedTask.Object);

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateExactIntValue(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()));

            var createTaskCommand = new CreateTaskCommand(mockedDatabase.Object, mockedFactory.Object, mockedValidator.Object);

            string taskName = "validName";
            string taskState = "validState";
            var commandParameters = new List<string>() { "0", "0", taskName, taskState };

            // act
            createTaskCommand.Execute(commandParameters);

            // assert
            mockedValidator.Verify(x => x.ValidateExactIntValue(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Execute_WhenEvrythingIsRight_ShouldCallTheProjectsPropertysIndexerOfTheDatabaseWithTheParsedId()
        {
            // arrange
            var mockedUser = new Mock<IUser>();
            var mockedUsersList = new List<IUser>() { mockedUser.Object };

            var mockedTasksList = new List<ITask>();

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.Users).Returns(mockedUsersList);
            mockedProject.Setup(x => x.Tasks).Returns(mockedTasksList);

            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Projects[0]).Returns(mockedProject.Object);

            var mockedTask = new Mock<ITask>();

            var mockedFactory = new Mock<IModelsFactory>();
            mockedFactory.Setup(x => x.CreateTask(It.IsAny<string>(), It.IsAny<IUser>(), It.IsAny<string>())).Returns(mockedTask.Object);

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateExactIntValue(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()));

            var createTaskCommand = new CreateTaskCommand(mockedDatabase.Object, mockedFactory.Object, mockedValidator.Object);

            string taskName = "validName";
            string taskState = "validState";
            var commandParameters = new List<string>() { "0", "0", taskName, taskState };

            // act
            createTaskCommand.Execute(commandParameters);

            // assert
            mockedDatabase.Verify(x => x.Projects[0], Times.Once);
        }

        [Test]
        public void Execute_WhenEvrythingIsRight_ShouldCallUsersPropertyIndexerOfTheProjectWithThePassedIdAndReturnTheExpectedUser()
        {
            // arrange
            var mockedUser = new Mock<IUser>();
            var mockedTasksList = new List<ITask>();

            var mockedUsersList = new List<IUser>() { mockedUser.Object };

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.Users).Returns(mockedUsersList);
            mockedProject.Setup(x => x.Tasks).Returns(mockedTasksList);

            var mockedProjectsList = new List<IProject>() { mockedProject.Object };

            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Projects).Returns(mockedProjectsList);

            var mockedTask = new Mock<ITask>();

            var mockedFactory = new Mock<IModelsFactory>();
            mockedFactory.Setup(x => x.CreateTask(It.IsAny<string>(), It.IsAny<IUser>(), It.IsAny<string>())).Returns(mockedTask.Object);

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateExactIntValue(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()));

            var createTaskCommand = new CreateTaskCommand(mockedDatabase.Object, mockedFactory.Object, mockedValidator.Object);

            string taskName = "validName";
            string taskState = "validState";
            var commandParameters = new List<string>() { "0", "0", taskName, taskState };

            // act
            createTaskCommand.Execute(commandParameters);

            // assert
            mockedFactory.Verify(x => x.CreateTask(
               It.IsAny<string>(),
               It.Is<IUser>(y => y == mockedUser.Object),
               It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Execute_WhenEvrythingIsRight_ShouldCreateNewTaskWithThoseParameters()
        {
            // arrange
            var mockedUser = new Mock<IUser>();
            var mockedUsersList = new List<IUser>() { mockedUser.Object };

            var mockedTasksList = new List<ITask>();

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.Users).Returns(mockedUsersList);
            mockedProject.Setup(x => x.Tasks).Returns(mockedTasksList);

            var mockedProjectsList = new List<IProject>() { mockedProject.Object };

            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Projects).Returns(mockedProjectsList);

            var mockedTask = new Mock<ITask>();

            var mockedFactory = new Mock<IModelsFactory>();
            mockedFactory.Setup(x => x.CreateTask(It.IsAny<string>(), It.IsAny<IUser>(), It.IsAny<string>())).Returns(mockedTask.Object);

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateExactIntValue(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()));

            var createTaskCommand = new CreateTaskCommand(mockedDatabase.Object, mockedFactory.Object, mockedValidator.Object);

            string taskName = "validName";
            string taskState = "validState";
            var commandParameters = new List<string>() { "0", "0", taskName, taskState };

            // act
            createTaskCommand.Execute(commandParameters);

            // assert
            mockedFactory.Verify(x => x.CreateTask(
                It.Is<string>(y => y == taskName),
                It.Is<IUser>(y => y == mockedUser.Object),
                It.Is<string>(y => y == taskState)), Times.Once);
        }

        [Test]
        public void Execute_WhenEvrytyingIsRight_ShouldAddTheCreatedTaskToTheProject()
        {
            // arrange
            var mockedUser = new Mock<IUser>();
            var mockedUsersList = new List<IUser>() { mockedUser.Object };

            var mockedTasksList = new List<ITask>();

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.Users).Returns(mockedUsersList);
            mockedProject.Setup(x => x.Tasks).Returns(mockedTasksList);

            var mockedProjectsList = new List<IProject>() { mockedProject.Object };

            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Projects).Returns(mockedProjectsList);

            var mockedTask = new Mock<ITask>();

            var mockedFactory = new Mock<IModelsFactory>();
            mockedFactory.Setup(x => x.CreateTask(It.IsAny<string>(), It.IsAny<IUser>(), It.IsAny<string>())).Returns(mockedTask.Object);

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateExactIntValue(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()));

            var createTaskCommand = new CreateTaskCommand(mockedDatabase.Object, mockedFactory.Object, mockedValidator.Object);

            string taskName = "validName";
            string taskState = "validState";
            var commandParameters = new List<string>() { "0", "0", taskName, taskState };

            // act
            createTaskCommand.Execute(commandParameters);

            // assert
            Assert.IsTrue(mockedTasksList.Contains(mockedTask.Object));
        }

        [Test]
        public void Execute_WhenEvrythingIsRight_ShouldReturnValidSuccessMessage()
        {
            // arrange
            var mockedUser = new Mock<IUser>();
            var mockedUsersList = new List<IUser>() { mockedUser.Object };

            var mockedTasksList = new List<ITask>();

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.Users).Returns(mockedUsersList);
            mockedProject.Setup(x => x.Tasks).Returns(mockedTasksList);

            var mockedProjectsList = new List<IProject>() { mockedProject.Object };

            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Projects).Returns(mockedProjectsList);

            var mockedTask = new Mock<ITask>();

            var mockedFactory = new Mock<IModelsFactory>();
            mockedFactory.Setup(x => x.CreateTask(It.IsAny<string>(), It.IsAny<IUser>(), It.IsAny<string>())).Returns(mockedTask.Object);

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateExactIntValue(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            mockedValidator.Setup(x => x.ValidateEmptyParameters(It.IsAny<IList<string>>(), It.IsAny<string>()));

            var createTaskCommand = new CreateTaskCommand(mockedDatabase.Object, mockedFactory.Object, mockedValidator.Object);

            string taskName = "validName";
            string taskState = "validState";
            var commandParameters = new List<string>() { "0", "0", taskName, taskState };

            string expectedMessage = "Successfully created";

            // act
            var result = createTaskCommand.Execute(commandParameters);

            // assert
            StringAssert.Contains(expectedMessage, result);
        }
    }
}
