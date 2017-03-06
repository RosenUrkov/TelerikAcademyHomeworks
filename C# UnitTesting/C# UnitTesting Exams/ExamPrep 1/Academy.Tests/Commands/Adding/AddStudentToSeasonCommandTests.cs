namespace Academy.Tests.Commands.Adding
{
    using NUnit.Framework;
    using Moq;
    using Academy.Core.Contracts;
    using System;
    using Academy.Commands.Adding;
    using System.Collections.Generic;
    using Academy.Models;
    using Academy.Models.Contracts;

    [TestFixture]
    public class AddStudentToSeasonCommandTests
    {
        [Test]
        public void Constructor_WhenPassedFactoryIsNull_ShouldThrowArgumentException()
        {
            var mockedEngine = new Mock<IEngine>();

            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, mockedEngine.Object));
        }

        [Test]
        public void Constructor_WhenPassedEngineIsNull_ShouldThrowArgumentException()
        {
            var mockedFactory = new Mock<IAcademyFactory>();

            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(mockedFactory.Object, null));
        }

        [Test]
        public void Constructor_WhenPassedParametersAreNull_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, null));
        }

        [Test]
        public void Constructor_WhenPassedParametersAreCorrect_ShouldAssignValuesCorrectly()
        {
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            var command = new AddStudentToSeasonCommand(mockedFactory.Object, mockedEngine.Object);

            Assert.AreSame(command.Engine, mockedEngine.Object);
            Assert.AreSame(command.Factory, mockedFactory.Object);

        }

        [Test]
        public void Execute_WhenThePassedStudentIsAlreadyPartOfThatSeason_ShouldThrowArgumentException()
        {
            var parameters = new List<string>() { "username", "0" };

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var studentList = new List<IStudent>() { student.Object };
            
            var season = new Mock<ISeason>();
            season.Setup(x => x.Students).Returns(studentList);

            var seasonList = new List<ISeason>() { season.Object };

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToSeasonCommand(factory.Object,engine.Object);

            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_WhenThePassedStudentIsCorrect_ShouldCorrectlyAddTheFoundStudentIntoTheSeason()
        {
            var parameters = new List<string>() { "username", "0" };
            var emptyStudentList = new List<IStudent>();

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var studentList = new List<IStudent>() { student.Object };

            var season = new Mock<ISeason>();
            season.Setup(x => x.Students).Returns(emptyStudentList);

            var seasonList = new List<ISeason>() { season.Object };            

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToSeasonCommand(factory.Object, engine.Object);
            command.Execute(parameters);

            Assert.IsTrue(emptyStudentList.Contains(student.Object));
        }

        [Test]
        public void Execute_WhenThePassedStudentIsCorrect_ShouldReturnASuccessMessageThatContainsStudentUsernameAndSeasonID()
        {
            var parameters = new List<string>() { "username", "0" };

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var season = new Mock<ISeason>();

            var studentList = new List<IStudent>() { student.Object };
            var seasonList = new List<ISeason>() { season.Object };
            var emptyStudentList = new List<IStudent>();

            season.Setup(x => x.Students).Returns(emptyStudentList);

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToSeasonCommand(factory.Object, engine.Object);

            var message = command.Execute(parameters);

            StringAssert.Contains(emptyStudentList[0].Username, message);
            StringAssert.Contains("0", message);
        }
    }
}
