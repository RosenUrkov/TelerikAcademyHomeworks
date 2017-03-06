namespace Academy.Tests.Models.Abstractions
{
    using NUnit.Framework;
    using Moq;
    using System;

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_WhenPassedCorrectParameters_ShouldCorrectlyAssignValues()
        {
            string username = "correctUsername";
            var user =new MockedUser(username);

            Assert.AreEqual(user.Username, username);
        }

        [TestCase("us")]
        [TestCase("incorrectUsernameMoreThan15Symb")]
        [TestCase(null)]
        public void Username_WhenPassedIncorrectParameter_ShouldThrowArgumentException(string username)
        {
            string corrUsername = "correctUsername";
            var user = new MockedUser(corrUsername);

            Assert.Throws<ArgumentException>(() => user.Username = username);

        }

        [Test]
        public void Username_WhenPassedCorrectParameter_ShouldNotThrow()
        {
            string corrUsername = "correctUsername";
            string anothUsername = "alsoUsername";
            var user = new MockedUser(corrUsername);

            Assert.DoesNotThrow(() => user.Username = anothUsername);

        }

        [Test]
        public void Username_WhenPassedCorrectParameter_ShouldAssignCorrectlyPassedValue()
        {
            string corrUsername = "correctUsername";
            string anothUsername = "alsoUsername";
            var user = new MockedUser(corrUsername);

            user.Username = anothUsername;

            Assert.AreEqual(user.Username, anothUsername);

        }
    }
}
