namespace Cosmetics.Tests
{
    using NUnit.Framework;
    using System;
    using Moq;
    using Common;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_ObjectParameterIsNull_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        [Test]
        public void CheckIfNull_ObjectParameterIsCorrect_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfNull(new object()));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CheckIfStringIsNullOrEmpty_TextIsNullOrEmpty_ShouldThrowNullReferenceException(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_TextIsNotNullOrEmpty_ShouldNotThrow()
        {
            string text = "correct string";

            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [TestCase("incorrect",200,100)]
        [TestCase("incorrect",3,1)]
        public void CheckIfStringLengthIsValid_TextIsLowerThanTheMinimumAllowedValueOrGreaterThanTheMaximumAllowedValue_ShouldThrowIndexOutOfRangeException(string text,int max,int min)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text,max,min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_TextIsInTheAllowedBounderies_ShouldNotThrow()
        {
            string text = "correct";
            int max = 20;
            int min = 2;

            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }


    }
}
