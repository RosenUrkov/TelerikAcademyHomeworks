namespace SchoolSystem.Tests.Models
{
    using NUnit.Framework;
    using Moq;
    using Enums;
    using Contracts;
    using Mocks;
    using System.Collections.Generic;

    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Constructor_WhenInitializingSubject_ShoudCallValidatorMethodValidateNumberRangeWithValidMessageParameter()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validSubject = Subjct.Bulgarian;

            string expectedMessage = "valid subject";

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var teacher = new MockedTeacher(validFirstName,validLastName,validSubject,mockedValidator.Object);

            // assert
            mockedValidator.Verify(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.Is<string>(y => y.Contains(expectedMessage))), Times.Once);
        }

        [Test]
        public void Constructor_WhenInitializingSubject_ShoudInitializeCorrectly()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validSubject = Subjct.Bulgarian;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var teacher = new MockedTeacher(validFirstName,validLastName,validSubject,mockedValidator.Object);

            // assert
            Assert.AreEqual(validSubject, teacher.Subject);
        }

        [Test]
        public void AddMark_ShoudCallValidatorMethodValidateNullObjectWithCorrectStudetntParameter()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validSubject = Subjct.Bulgarian;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            var teacher = new MockedTeacher(validFirstName, validLastName, validSubject, mockedValidator.Object);

            float validValue = 5.6f;

            var fakeMarks = new List<IMark>();
            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(x => x.Marks).Returns(fakeMarks);

            // act
            teacher.AddMark(mockedStudent.Object, validValue);

            // assert
            mockedValidator.Verify(x => x.ValidateNullObject(It.Is<IStudent>(y => y == mockedStudent.Object), It.IsAny<string>()),Times.Once);
        }

        [Test]
        public void AddMark_WhenEvrythingIsCorrect_ShoudAddNewCineToTheStudent()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validSubject = Subjct.Bulgarian;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            var teacher = new MockedTeacher(validFirstName, validLastName, validSubject, mockedValidator.Object);

            float validValue = 5.6f;

            var fakeMarks = new List<IMark>();
            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(x => x.Marks).Returns(fakeMarks);

            // act
            teacher.AddMark(mockedStudent.Object, validValue);

            // assert
            Assert.AreEqual(1, fakeMarks.Count);
        }

        [Test]
        public void AddMark_WhenEvrythingIsCorrect_ShoudAddNewCineWithCorrectSubjectAndValueToTheStudent()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validSubject = Subjct.Bulgarian;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            var teacher = new MockedTeacher(validFirstName, validLastName, validSubject, mockedValidator.Object);

            float validValue = 5.6f;

            var fakeMarks = new List<IMark>();
            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(x => x.Marks).Returns(fakeMarks);

            // act
            teacher.AddMark(mockedStudent.Object, validValue);

            // assert
            Assert.AreEqual(validSubject, fakeMarks[0].Subject);
            Assert.AreEqual(validValue, fakeMarks[0].Value);
        }
    }
}
