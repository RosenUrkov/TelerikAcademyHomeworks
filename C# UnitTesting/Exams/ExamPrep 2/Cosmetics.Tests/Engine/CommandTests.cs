namespace Cosmetics.Tests.Engine
{
    using Cosmetics.Engine;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CommandTests
    {
        // check later
        [Test]
        public void Parse_InputStringIsInTheValidCorrectFormat_ShouldReturnNewCommand()
        {
            string correctInput = "correct";

            var command = Command.Parse(correctInput);

            Assert.IsInstanceOf(typeof(Command), command);
        }

        [Test]
        public void Parse_InputStringIsInTheValidCorrectFormat_ShouldSetCorrectValuesToCommandObjectParametersNameAndParameters()
        {
            string correctInput = "name firstParameter secondParameter";
            string name = "name";
            int paramsCount = 2;

            var command = Command.Parse(correctInput);

            Assert.AreEqual(command.Name, name);
            Assert.AreEqual(command.Parameters.Count, paramsCount);
        }

        [Test]
        public void Parse_InputStringIsNull_ShouldThrowNullReferenceException()
        {
            string incorrectInput = null;

            Assert.Throws<NullReferenceException>(() => Command.Parse(incorrectInput));
        }

        [Test]
        public void Parse_InputStringThatRepresentsTheCommandNameIsNullOrEmpty_ShouldThrowArgumentNullExceptionWithTheStringNameInTheMessage()
        {
            string incorrectName = "";

            Assert.That(() => Command.Parse(incorrectName), Throws.ArgumentNullException.With.Message.Contains("Name"));
        } 

        [Test]
        public void Parse_InputStringThatRepresentsTheCommandParametersIsNullOrEmpty_ShouldThrowArgumentNullExceptionWithTheStringListInTheMessage()
        {
            string incorrectParameters = "name ";

            Assert.That(() => Command.Parse(incorrectParameters), Throws.ArgumentNullException.With.Message.Contains("List"));
        }        

    }
}
