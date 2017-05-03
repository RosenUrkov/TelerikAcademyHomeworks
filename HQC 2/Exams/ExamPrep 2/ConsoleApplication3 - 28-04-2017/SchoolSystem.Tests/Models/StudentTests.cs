namespace SchoolSystem.Tests.Models
{
    using NUnit.Framework;
    using Moq;
    using Mocks;
    using Contracts;
    using Enums;
    using SchoolSystem.Models;

    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Constructor_WhenInitializingGrade_ShoudCallValidatorMethodValidateNumberRange()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validGrade = Grade.Second;

            string expectedMessage = "valid grade";

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var student = new MockedStudent(validFirstName, validLastName, validGrade, mockedValidator.Object);

            // assert
            mockedValidator.Verify(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.Is<string>(y => y.Contains(expectedMessage))), Times.Once);
        }

        [Test]
        public void Constructor_WhenInitializingGrade_ShoudInitializeCorrectly()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validGrade = Grade.Second;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var student = new MockedStudent(validFirstName, validLastName, validGrade, mockedValidator.Object);

            // assert
            Assert.AreEqual(validGrade, student.Grade);
        }

        [Test]
        public void Constructor_WhenInitializingMarks_ShoudInitializeMarksCorrectly()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validGrade = Grade.Second;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var student = new MockedStudent(validFirstName, validLastName, validGrade, mockedValidator.Object);

            // assert
            Assert.IsNotNull(student.Marks);
        }

        [Test]
        public void Constructor_WhenInitializingMarks_MarksShoudBeEmpty()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validGrade = Grade.Second;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var student = new MockedStudent(validFirstName, validLastName, validGrade, mockedValidator.Object);

            // assert
            Assert.AreEqual(0,student.Marks.Count);
        }

        [Test]
        public void ListMarks_WhenMarksAreZero_ShouldReturnCorrectString()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validGrade = Grade.Second;            

            var student = new Student(validFirstName, validLastName, validGrade);

            string expectedMessage = "This student has no marks.";

            // act
            string result = student.ListMarks();

            // assert
            Assert.AreSame(expectedMessage, result);
        }

        [Test]
        public void ListMarks_WhenStudentHasMarks_ShouldStringContainingValidMessage()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validGrade = Grade.Second;

            var student = new Student(validFirstName, validLastName, validGrade);

            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(x => x.Subject).Returns(Subjct.Math);
            mockedMark.Setup(x => x.Value).Returns(3f);

            student.Marks.Add(mockedMark.Object);

            string expectedMessage = "The student has these marks:";

            // act
            string result = student.ListMarks();

            // assert
            StringAssert.Contains(expectedMessage, result);
        }

        [Test]
        public void ListMarks_WhenStudentHasMarks_ShouldStringContainingValidMarksInfo()
        {
            // arrange
            var validFirstName = "firstName";
            var validLastName = "fastName";
            var validGrade = Grade.Second;

            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(x => x.Subject).Returns(Subjct.Math);
            mockedMark.Setup(x => x.Value).Returns(3f);

            var student = new Student(validFirstName, validLastName, validGrade);
            student.Marks.Add(mockedMark.Object);

            string expectedMessage = "Math => 3";

            // act
            string result = student.ListMarks();

            // assert
            StringAssert.Contains(expectedMessage, result);
        }
    }
}
