namespace AcademyEcosystemCLI.Tests.Core
{
    using NUnit.Framework;
    using Moq;
    using Contracts;
    using Mocks;

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Constructor_WhenInitializingWriter_ShouldCallValidatorWIthCorrectMessage()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            var expectedMessage = "Writer";

            // act
            var engine = new EngineMock(readerMock.Object, writerMock.Object, validatorMock.Object);

            // assert
            validatorMock.Verify(x => x.ValidateNullObject(It.Is<IWriter>(y => y == writerMock.Object), It.Is<string>(y => y.Contains(expectedMessage))),Times.Once);
        }

        [Test]
        public void Constructor_WhenInitializingWriter_ShouldInitializeWriterCorrectly()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            // act
            var engine = new EngineMock(readerMock.Object, writerMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(writerMock.Object, engine.getWriter());
        }

        [Test]
        public void Constructor_WhenInitializingReader_ShouldCallValidatorWIthCorrectMessage()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            var expectedMessage = "Reader";

            // act
            var engine = new EngineMock(readerMock.Object, writerMock.Object, validatorMock.Object);

            // assert
            validatorMock.Verify(x => x.ValidateNullObject(It.Is<IReader>(y => y == readerMock.Object), It.Is<string>(y => y.Contains(expectedMessage))),Times.Once);
        }

        [Test]
        public void Constructor_WhenInitializingReader_ShouldInitializeReaderCorrectly()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            // act
            var engine = new EngineMock(readerMock.Object, writerMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(readerMock.Object, engine.GetReader());
        }

        [Test]
        public void Constructor_WhenNullIsPassedToValidator_ShouldInitializeCorrectly()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            
            // act
            var engine = new EngineMock(readerMock.Object, writerMock.Object, null);

            // assert
            Assert.IsInstanceOf<IValidator>(engine.GetValidator());
        }

        [Test]
        public void Constructor_WhenCorrectValidatorIsPassed_ShouldInitializeToPassedValidator()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var validatorMock = new Mock<IValidator>();
            
            // act
            var engine = new EngineMock(readerMock.Object, writerMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(validatorMock.Object, engine.GetValidator());
        }

        [Test]
        public void Constructor_WhenEvrythingIsCorrect_ShouldInitializeAllOrganismsListCorrectly()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var validatorMock = new Mock<IValidator>();

            // act
            var engine = new EngineMock(readerMock.Object, writerMock.Object, validatorMock.Object);

            // assert
            Assert.IsNotNull(engine.GetOrganisms());
        }
    }
}
