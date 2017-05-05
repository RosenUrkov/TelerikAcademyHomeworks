namespace ProjectManager.Tests.Core
{
    using NUnit.Framework;
    using Moq;
    using ProjectManager.Core.Contracts;
    using ProjectManager.Core;
    using Common.CustomExceptions;
    using System;

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Start_WhenEvrythingIsCorrect_ShoudCallReaderReadLineMethodOnce()
        {
            // arrange
            string endCommand = "exit";

            var mockedReader = new Mock<IReader>();
            mockedReader.Setup(x => x.ReadLine()).Returns(endCommand);

            var mockedWriter = new Mock<IWriter>();
            mockedWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedProcessor = new Mock<ICommandProcessor>();
            var mockedLogger = new Mock<IFileLogger>();

            var engine = new Engine(mockedProcessor.Object, mockedWriter.Object, mockedReader.Object, mockedLogger.Object);

            // act
            engine.Start();

            // assert
            mockedReader.Verify(x => x.ReadLine(), Times.Once);
        }

        [Test]
        public void Start_WhenPassedEndCommand_ShoudCallWriterWriteLineMethodOnce()
        {
            // arrange
            string endCommand = "exit";

            var mockedReader = new Mock<IReader>();
            mockedReader.Setup(x => x.ReadLine()).Returns(endCommand);

            var mockedWriter = new Mock<IWriter>();
            mockedWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedProcessor = new Mock<ICommandProcessor>();
            var mockedLogger = new Mock<IFileLogger>();

            var engine = new Engine(mockedProcessor.Object, mockedWriter.Object, mockedReader.Object, mockedLogger.Object);

            string endCommandMessage = "Program terminated.";

            // act
            engine.Start();

            // assert
            mockedWriter.Verify(x => x.WriteLine(It.Is<string>(y => y == endCommandMessage)), Times.Once);
        }

        [Test]
        public void Start_WhenCommandIsValid_ShoudCallWriteLineMethodWithCorrectString()
        {
            // arrange
            string endCommand = "exit";
            string validCommand = "validCommand";

            var mockedReader = new Mock<IReader>();
            mockedReader.SetupSequence(x => x.ReadLine()).Returns(validCommand).Returns(endCommand);

            string validResult = "validResult";

            var mockedProcessor = new Mock<ICommandProcessor>();
            mockedProcessor.Setup(x => x.Process(It.IsAny<string>())).Returns(validResult);

            var mockedWriter = new Mock<IWriter>();
            mockedWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedLogger = new Mock<IFileLogger>();

            var engine = new Engine(mockedProcessor.Object, mockedWriter.Object, mockedReader.Object, mockedLogger.Object);

            // act
            engine.Start();

            // assert
            mockedWriter.Verify(x => x.WriteLine(It.Is<string>(y => y == validResult)), Times.Once);
        }

        [Test]
        public void Start_WhenUserValidationExceptionOccurs_ShoudCallWriteLineMethodWithTheExceptionMessage()
        {
            // arrange
            string endCommand = "exit";
            string validCommand = "validCommand";

            var mockedReader = new Mock<IReader>();
            mockedReader.SetupSequence(x => x.ReadLine()).Returns(validCommand).Returns(endCommand);

            var validExceptionMessage = "validMessage";
            var mockedProcessor = new Mock<ICommandProcessor>();
            mockedProcessor.Setup(x => x.Process(It.IsAny<string>())).Throws(new UserValidationException(validExceptionMessage));

            var mockedWriter = new Mock<IWriter>();
            mockedWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedLogger = new Mock<IFileLogger>();

            var engine = new Engine(mockedProcessor.Object, mockedWriter.Object, mockedReader.Object, mockedLogger.Object);

            // act
            engine.Start();

            // assert
            mockedWriter.Verify(x => x.WriteLine(It.Is<string>(y => y.Contains(validExceptionMessage))), Times.Once);
        }

        [Test]
        public void Start_WhenGenericExceptionOccurs_ShoudCallLoggerErrorMethodWithTheExceptionMessage()
        {
            // arrange
            string endCommand = "exit";
            string validCommand = "validCommand";

            var mockedReader = new Mock<IReader>();
            mockedReader.SetupSequence(x => x.ReadLine()).Returns(validCommand).Returns(endCommand);

            var validExceptionMessage = "validMessage";
            var mockedProcessor = new Mock<ICommandProcessor>();
            mockedProcessor.Setup(x => x.Process(It.IsAny<string>())).Throws(new Exception(validExceptionMessage));

            var mockedWriter = new Mock<IWriter>();
            mockedWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedLogger = new Mock<IFileLogger>();
            mockedLogger.Setup(x => x.Error(It.IsAny<string>()));

            var engine = new Engine(mockedProcessor.Object, mockedWriter.Object, mockedReader.Object, mockedLogger.Object);

            // act
            engine.Start();

            // assert
            mockedLogger.Verify(x => x.Error(It.Is<string>(y => y == validExceptionMessage)), Times.Once);
        }

        [Test]
        public void Start_WhenGenericExceptionOccurs_ShoudCallWriteLineMethodWithValidMessage()
        {
            // arrange
            string endCommand = "exit";
            string validCommand = "validCommand";

            var mockedReader = new Mock<IReader>();
            mockedReader.SetupSequence(x => x.ReadLine()).Returns(validCommand).Returns(endCommand);

            var validExceptionMessage = "something happened";
            var mockedProcessor = new Mock<ICommandProcessor>();
            mockedProcessor.Setup(x => x.Process(It.IsAny<string>())).Throws(new Exception(validExceptionMessage));

            var mockedWriter = new Mock<IWriter>();
            mockedWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedLogger = new Mock<IFileLogger>();
            mockedLogger.Setup(x => x.Error(It.IsAny<string>()));

            var engine = new Engine(mockedProcessor.Object, mockedWriter.Object, mockedReader.Object, mockedLogger.Object);

            // act
            engine.Start();

            // assert
            mockedWriter.Verify(x => x.WriteLine(It.Is<string>(y => y.Contains(validExceptionMessage))), Times.Once);
        }
    }
}
