namespace PackageManager.Tests.Models
{
    using Enums;
    using NUnit.Framework;
    using PackageManager.Models;
    using System;

    [TestFixture]
    public class PackageVersionTests
    {
        [Test]
        public void Constructor_WhenValidParametersArePassed_ShouldSetTheMajorCorrectly()
        {
            // arrange
            int validMajor = 5;
            int validMinor = 2;
            int validPatch = 7;

            // act
            var version = new PackageVersion(validMajor, validMinor, validPatch, Enums.VersionType.alpha);

            // assert
            Assert.AreEqual(validMajor, version.Major);
        }

        [Test]
        public void Constructor_WhenValidParametersArePassed_ShouldSetTheMinorCorrectly()
        {
            // arrange
            int validMajor = 5;
            int validMinor = 2;
            int validPatch = 7;

            // act
            var version = new PackageVersion(validMajor, validMinor, validPatch, Enums.VersionType.alpha);

            // assert
            Assert.AreEqual(validMinor, version.Minor);
        }

        [Test]
        public void Constructor_WhenValidParametersArePassed_ShouldSetThePatchCorrectly()
        {
            // arrange
            int validMajor = 5;
            int validMinor = 2;
            int validPatch = 7;

            // act
            var version = new PackageVersion(validMajor, validMinor, validPatch, Enums.VersionType.alpha);

            // assert
            Assert.AreEqual(validPatch, version.Patch);
        }

        [Test]
        public void Constructor_WhenValidParametersArePassed_ShouldSetTheVersionTypeCorrectly()
        {
            // arrange
            int validMajor = 5;
            int validMinor = 2;
            int validPatch = 7;

            // act
            var version = new PackageVersion(validMajor, validMinor, validPatch, Enums.VersionType.alpha);

            // assert
            Assert.AreEqual(Enums.VersionType.alpha, version.VersionType);
        }

        [Test]
        public void SetValues_WhenValidParameterIsPassed_ShouldNotThrow()
        {
            // arrange
            int validMajor = 6;
            int validMinor = 2;
            int validPatch = 7;

            // act & assert
            Assert.DoesNotThrow(() => new PackageVersion(validMajor, validMinor, validPatch, Enums.VersionType.alpha));
        }

        [Test]
        public void SetMajor_WhenInvalidParameterIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            int invalidMajor = -3;
            int validMinor = 2;
            int validPatch = 7;

            // act & assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(invalidMajor, validMinor, validPatch, Enums.VersionType.alpha));
        }
               

        [Test]
        public void SetMinor_WhenInvalidParameterIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            int validMajor = 6;
            int invalidMinor = -2;
            int validPatch = 7;

            // act & assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(validMajor, invalidMinor, validPatch, Enums.VersionType.alpha));
        }
        
        [Test]
        public void SetPatch_WhenInvalidParameterIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            int validMajor = 3;
            int validMinor = 2;
            int invalidPatch = -7;

            // act & assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(validMajor, validMinor, invalidPatch, Enums.VersionType.alpha));
        }

       

        [Test]
        public void SetVersionType_WhenInvalidParameterIsPassed_ShouldThrowArgumentException()
        {
            // arrange
            int validMajor = 3;
            int validMinor = 2;
            int validPatch = 7;
            var invalidType = (VersionType)200;

            // act & assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(validMajor, validMinor, validPatch, invalidType));
        }
    }
}
