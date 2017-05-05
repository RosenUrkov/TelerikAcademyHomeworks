namespace SchoolSystem.Tests.Core
{
    using Mocks;
    using Moq;
    using NUnit.Framework;
    using SchoolSystem.Contracts;
    using SchoolSystem.Core;
    using System.Collections.Generic;

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Constructor_WhenReaderIsInitialized_CallValidatorWithValidMessage()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            string expectedMessage = "Reader must not be null";

            // act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            validatorMock.Verify(x => x.ValidateNullObject(It.Is<IReader>(y=>y==readerMock.Object), It.Is<string>(y => y == expectedMessage)), Times.Once);
        }

        [Test]
        public void Constructor_WhenWriterIsInitialized_CallValidatorWithValidMessage()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            string expectedMessage = "Writer must not be null";

            // act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            validatorMock.Verify(x => x.ValidateNullObject(It.Is<IWriter>(y=>y==writerMock.Object), It.Is<string>(y => y == expectedMessage)), Times.Once);
        }

        [Test]
        public void Constructor_WhenCommandParserIsInitialized_CallValidatorWithValidMessage()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.ValidateNullObject(It.IsAny<object>(), It.IsAny<string>()));

            string expectedMessage = "Parser must not be null";

            // act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            validatorMock.Verify(x => x.ValidateNullObject(It.Is<ICommandParser>(y => y == parserMock.Object), It.Is<string>(y => y == expectedMessage)), Times.Once);
        }

        [Test]
        public void Constructor_WhenValidatorIsNull_ShouldNotThrow()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();

            // act & assert
            Assert.DoesNotThrow(() => new Engine(readerMock.Object, writerMock.Object, parserMock.Object, null));
        }

        [Test]
        public void Constructor_WhenValidatorIsNull_ShouldCreateNewValidator()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();

            // act
            var engine = new MockedEngine(readerMock.Object, writerMock.Object, parserMock.Object, null);

            // assert
            Assert.IsInstanceOf<IValidator>(engine.GetValidator());
        }

        [Test]
        public void Constructor_WhenValidatorIsCorrect_ShouldInitializeValidator()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var validatorMock = new Mock<IValidator>();

            // act
            var engine = new MockedEngine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(validatorMock.Object, engine.GetValidator());
        }

        [Test]
        public void Constructor_WhenParametersAreCorrect_ShouldNotThrow()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var validatorMock = new Mock<IValidator>();

            // act & assert
            Assert.DoesNotThrow(() => new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object));
        }

        [Test]
        public void Constructor_WhenParametersAreCorrect_ShouldAssignReaderCorrectly()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var validatorMock = new Mock<IValidator>();

            // act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(readerMock.Object, engine.Reader);
        }

        [Test]
        public void Constructor_WhenParametersAreCorrect_ShouldAssignWriterCorrectly()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var validatorMock = new Mock<IValidator>();

            // act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(writerMock.Object, engine.Writer);
        }

        [Test]
        public void Constructor_WhenParametersAreCorrect_ShouldAssignCommandParserCorrectly()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var validatorMock = new Mock<IValidator>();

            // act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(parserMock.Object, engine.Parser);
        }

        [Test]
        public void Constructor_WhenParametersAreCorrect_ShouldAssignValidatorCorrectly()
        {
            // arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var validatorMock = new Mock<IValidator>();

            // act
            var engine = new MockedEngine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // assert
            Assert.AreSame(validatorMock.Object, engine.GetValidator());
        }

        [Test]
        public void Students_ShoudBeInitialized()
        {
            Assert.IsNotNull(Engine.Students);
        }

        [Test]
        public void Students_WhenNoStudentIsAdded_ShoudBeEmptyDictionary()
        {
            Assert.AreEqual(Engine.Students.Count, 0);
        }

        [Test]
        public void Teachers_ShoudBeInitialized()
        {
            Assert.IsNotNull(Engine.Teachers);
        }

        [Test]
        public void Teachers_WhenNoStudentIsAdded_ShoudBeEmptyDictionary()
        {
            Assert.AreEqual(Engine.Teachers.Count, 0);
        }

        [Test]
        public void Start_WhenReadedCommandIsEnd_ShoudNotCallParseCommand()
        {
            // arrange
            string endCommand = "End";

            var readerMock = new Mock<IReader>();
            readerMock.Setup(x => x.ReadLine()).Returns(endCommand);

            var parserMock = new Mock<ICommandParser>();
            parserMock.Setup(x => x.ParseCommand(It.IsAny<string>()));

            var writerMock = new Mock<IWriter>();
            var validatorMock = new Mock<IValidator>();

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // act
            engine.Start();

            // assert
            parserMock.Verify(x => x.ParseCommand(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Start_WhenReadedCommandIsEnd_ShoudNotCallWriteLine()
        {
            // arrange
            string endCommand = "End";

            var readerMock = new Mock<IReader>();
            readerMock.Setup(x => x.ReadLine()).Returns(endCommand);

            var writerMock = new Mock<IWriter>();
            writerMock.Setup(x => x.WriteLine(It.IsAny<string>()));

            var parserMock = new Mock<ICommandParser>();

            var validatorMock = new Mock<IValidator>();

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // act
            engine.Start();

            // assert
            writerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Start_WhenReadedCommandIsValid_ShoudCallParseCommandWithCorrectCommand()
        {
            // arrange
            string validCommand = "CreateStudent Pesho Petrov 10";
            string endCommand = "End";

            var readerMock = new Mock<IReader>();
            readerMock.SetupSequence(x => x.ReadLine()).Returns(validCommand).Returns(endCommand);

            var writerMock = new Mock<IWriter>();
            writerMock.Setup(x => x.WriteLine(It.IsAny<string>()));

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns("valid string");

            var parserMock = new Mock<ICommandParser>();
            parserMock.Setup(x => x.ParseCommand(It.IsAny<string>())).Returns(commandMock.Object);

            var validatorMock = new Mock<IValidator>();

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // act
            engine.Start();

            // assert
            parserMock.Verify(x => x.ParseCommand(It.Is<string>(y=>y==validCommand)), Times.Once);
        }

        [Test]
        public void Start_WhenReadedCommandIsValid_ShoudCallExecuteOnTheParsedCommandWithCorrectParameters()
        {
            // arrange
            string validCommand = "CreateStudent Pesho Petrov 10";
            string endCommand = "End";
            
            var readerMock = new Mock<IReader>();
            readerMock.SetupSequence(x => x.ReadLine()).Returns(validCommand).Returns(endCommand);

            var writerMock = new Mock<IWriter>();
            writerMock.Setup(x => x.WriteLine(It.IsAny<string>()));

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns("valid string");

            var parserMock = new Mock<ICommandParser>();
            parserMock.Setup(x => x.ParseCommand(It.IsAny<string>())).Returns(commandMock.Object);

            var validatorMock = new Mock<IValidator>();

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // act
            engine.Start();

            // assert
            commandMock.Verify(x => x.Execute(It.IsAny<IList<string>>()), Times.Once);
        }

        [Test]
        public void Start_WhenReadedCommandIsValid_ShoudCallWriteLineWithCorrectParameters()
        {
            // arrange
            string validCommand = "CreateStudent Pesho Petrov 10";
            string endCommand = "End";

            string validExecutedCommand = "some valid string";            

            var readerMock = new Mock<IReader>();
            readerMock.SetupSequence(x => x.ReadLine()).Returns(validCommand).Returns(endCommand);

            var writerMock = new Mock<IWriter>();
            writerMock.Setup(x => x.WriteLine(It.IsAny<string>()));

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(validExecutedCommand);

            var parserMock = new Mock<ICommandParser>();
            parserMock.Setup(x => x.ParseCommand(It.IsAny<string>())).Returns(commandMock.Object);

            var validatorMock = new Mock<IValidator>();

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, validatorMock.Object);

            // act
            engine.Start();

            // assert
            writerMock.Verify(x => x.WriteLine(It.Is<string>(y => y == validExecutedCommand)), Times.Once);
        }
    }
}
