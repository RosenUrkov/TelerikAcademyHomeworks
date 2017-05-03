namespace SchoolSystemTests.Models
{
    using NUnit.Framework;
    using SchoolSystem.Enums;
    using Moq;
    using SchoolSystem.Contracts;
    using SchoolSystem.Tests.Models.Mocks;
    using SchoolSystem.Models;

    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void Constructor_WhenInitializingSubject_ShoudCallValidatorMethodValidateNumberRangeWithValidMessageParameter()
        {
            // arrange
            var validSubject = Subjct.Bulgarian;
            float validValue = 5.6f;

            string expectedMessage = "valid subject";

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var mark = new MockedMark(validSubject, validValue, mockedValidator.Object);

            // assert
            mockedValidator.Verify(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.Is<string>(y => y.Contains(expectedMessage))), Times.Once);
        }

        [Test]
        public void Constructor_WhenInitializingSubject_ShoudInitializeCorrectly()
        {
            // arrange
            var validSubject = Subjct.Bulgarian;
            float validValue = 5.6f;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var mark = new MockedMark(validSubject, validValue, mockedValidator.Object);

            // assert
            Assert.AreEqual(validSubject, mark.Subject);
        }

        [Test]
        public void Constructor_WhenInitializingValue_ShoudCallValidatorMethodValidateNumberRangeWithValidMessageParameter()
        {
            // arrange
            var validSubject = Subjct.Bulgarian;
            float validValue = 5.6f;

            string expectedMessage = "valid value";

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<float>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var mark = new MockedMark(validSubject, validValue, mockedValidator.Object);

            // assert
            mockedValidator.Verify(x => x.ValidateNumberRange(It.IsAny<float>(), It.IsAny<int>(), It.IsAny<int>(), It.Is<string>(y => y.Contains(expectedMessage))), Times.Once);
        }

        [Test]
        public void Constructor_WhenInitializingValue_ShoudInitializeCorrectly()
        {
            // arrange
            var validSubject = Subjct.Bulgarian;
            float validValue = 5.6f;

            var mockedValidator = new Mock<IValidator>();
            mockedValidator.Setup(x => x.ValidateNumberRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // act
            var mark = new MockedMark(validSubject, validValue, mockedValidator.Object);

            // assert
            Assert.AreEqual(validValue, mark.Value);
        }

        [Test]
        public void Constructor_WhenValidatorIsNull_ShouldCreateNewValidator()
        {
            // arrange
            var validSubject = Subjct.Bulgarian;
            float validValue = 5.6f;

            // act
            var mark = new MockedMark(validSubject,validValue, null);

            // assert
            Assert.IsInstanceOf<IValidator>(mark.GetValidator());
        }

        [Test]
        public void Constructor_WhenValidatorIsPassed_ShouldCorrectlyInitializeValidator()
        {
            // arrange
            var validSubject = Subjct.Bulgarian;
            float validValue = 5.6f;
            var mockedValidator = new Mock<IValidator>();

            // act
            var mark = new MockedMark(validSubject, validValue, mockedValidator.Object);

            // assert
            Assert.AreSame(mockedValidator.Object, mark.GetValidator());
        }
    }
}
