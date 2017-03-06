namespace Academy.Tests.Commands.Adding
{
    using NUnit.Framework;
    using Moq;
    using Academy.Core.Contracts;
    using System;
    using Academy.Commands.Adding;
    using System.Collections.Generic;
    using Academy.Models.Contracts;

    [TestFixture]
    public class AddStudentToCourseCommandTests
    {
        [Test]
        public void Constructor_WhenPassedFactoryIsNull_ShouldThrowArgumentException()
        {
            var mockedEngine = new Mock<IEngine>();

            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, mockedEngine.Object));
        }

        [Test]
        public void Constructor_WhenPassedEngineIsNull_ShouldThrowArgumentException()
        {
            var mockedFactory = new Mock<IAcademyFactory>();

            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(mockedFactory.Object, null));
        }

        [Test]
        public void Constructor_WhenPassedParametersAreNull_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, null));
        }

        [Test]
        public void Constructor_WhenPassedParametersAreCorrect_ShouldAssignValuesCorrectly()
        {
            var mockedFactory = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();

            var command = new AddStudentToCourseCommand(mockedFactory.Object, mockedEngine.Object);

            Assert.AreSame(command.Engine, mockedEngine.Object);
            Assert.AreSame(command.Factory, mockedFactory.Object);

        }

        [Test]
        public void Execute_WhenThePassedCourseFormIsInvalid_ShouldThrowArgumentException()
        {
            var parameters = new List<string>() { "username", "0", "0", "invalidForm" };

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var season = new Mock<ISeason>();
            var course = new Mock<ICourse>();

            var studentList = new List<IStudent>() { student.Object };
            var seasonList = new List<ISeason>() { season.Object };
            var courseList = new List<ICourse>() { course.Object };

            season.Setup(x => x.Courses).Returns(courseList);
            season.Setup(x => x.Students).Returns(studentList);

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToCourseCommand(factory.Object, engine.Object);

            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_WhenThePassedStudentIsCorrect_ShouldCorrectlyAddTheFoundStudentIntoTheCourseInTheCorrespondingAttendinceFormOnsite()
        {
            var parameters = new List<string>() { "username", "0", "0", "onsite" };

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var season = new Mock<ISeason>();
            var course = new Mock<ICourse>();

            var emptyStudentsList = new List<IStudent>();
            course.Setup(x => x.OnsiteStudents).Returns(emptyStudentsList);

            var studentList = new List<IStudent>() { student.Object };
            var courseList = new List<ICourse>() { course.Object };

            season.Setup(x => x.Courses).Returns(courseList);
            season.Setup(x => x.Students).Returns(studentList);
            var seasonList = new List<ISeason>() { season.Object };

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToCourseCommand(factory.Object, engine.Object);

            command.Execute(parameters);

            Assert.IsTrue(emptyStudentsList.Contains(student.Object));
        }

        [Test]
        public void Execute_WhenThePassedStudentIsCorrect_ShouldCorrectlyAddTheFoundStudentIntoTheCourseInTheCorrespondingAttendinceFormOnline()
        {
            var parameters = new List<string>() { "username", "0", "0", "online" };

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var season = new Mock<ISeason>();
            var course = new Mock<ICourse>();

            var emptyStudentsList = new List<IStudent>();
            course.Setup(x => x.OnlineStudents).Returns(emptyStudentsList);

            var studentList = new List<IStudent>() { student.Object };
            var courseList = new List<ICourse>() { course.Object };

            season.Setup(x => x.Courses).Returns(courseList);
            season.Setup(x => x.Students).Returns(studentList);
            var seasonList = new List<ISeason>() { season.Object };

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToCourseCommand(factory.Object, engine.Object);

            command.Execute(parameters);

            Assert.IsTrue(emptyStudentsList.Contains(student.Object));
        }

        [Test]
        public void Execute_WhenThePassedStudentIsCorrect_ShouldReturnASuccessMessageThatContainsStudentUsernameAndSeasonID()
        {
            var parameters = new List<string>() { "username", "0", "0", "online" };

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var season = new Mock<ISeason>();
            var course = new Mock<ICourse>();

            var emptyStudentsList = new List<IStudent>();
            course.Setup(x => x.OnlineStudents).Returns(emptyStudentsList);

            var studentList = new List<IStudent>() { student.Object };
            var courseList = new List<ICourse>() { course.Object };

            season.Setup(x => x.Courses).Returns(courseList);
            season.Setup(x => x.Students).Returns(studentList);
            var seasonList = new List<ISeason>() { season.Object };

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToCourseCommand(factory.Object, engine.Object);

            var message = command.Execute(parameters);

            StringAssert.Contains(emptyStudentsList[0].Username, message);
            StringAssert.Contains("0", message);
        }

        [Test]
        public void Execute_WhenThePassedStudentIsInvalid_ShouldThrowAExceptionThatHasMessageThatContainsTheInvalidFormName()
        {
            var parameters = new List<string>() { "username", "0", "0", "invalidForm" };

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns("username");

            var season = new Mock<ISeason>();
            var course = new Mock<ICourse>();

            var emptyStudentsList = new List<IStudent>();

            var studentList = new List<IStudent>() { student.Object };
            var courseList = new List<ICourse>() { course.Object };

            season.Setup(x => x.Courses).Returns(courseList);
            season.Setup(x => x.Students).Returns(studentList);
            var seasonList = new List<ISeason>() { season.Object };

            var engine = new Mock<IEngine>();
            engine.Setup(x => x.Students).Returns(studentList);
            engine.Setup(x => x.Seasons).Returns(seasonList);

            var factory = new Mock<IAcademyFactory>();

            var command = new AddStudentToCourseCommand(factory.Object, engine.Object);

            Assert.That(() => command.Execute(parameters), Throws.ArgumentException.With.Message.Contains("invalidForm"));
        }
    }
}
