namespace PackageManager.Tests.Models
{
    using NUnit.Framework;
    using Moq;
    using PackageManager.Models.Contracts;
    using PackageManager.Models;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class PackageTests
    {
        [Test]
        public void Constructor_WhenDependenciesAreNotPassed_ShouldSetTheFieldCorrectlyWithTheDefaultParameter()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            // act
            var package = new Package(validName, mockedVersion.Object);

            // assert
            Assert.IsInstanceOf<HashSet<IPackage>>(package.Dependencies);
        }

        [Test]
        public void Constructor_WhenDependenciesArePassed_ShouldSetTheFieldCorrectlyWithThePassedParameter()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();
            var mockedDependencies = new Mock<ICollection<IPackage>>();

            // act
            var package = new Package(validName, mockedVersion.Object,mockedDependencies.Object);

            // assert
            Assert.AreSame(mockedDependencies.Object, package.Dependencies);
        }

        [Test]
        public void PropertyName_WhenValidParametersArePassed_ShouldSetTheNameCorrectly()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            // act
            var package = new Package(validName, mockedVersion.Object);

            // assert
            Assert.AreEqual(validName, package.Name);
        }

        [Test]
        public void PropertyVersion_WhenValidParametersArePassed_ShouldSetTheVersionCorrectly()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            // act
            var package = new Package(validName, mockedVersion.Object);

            // assert
            Assert.AreSame(mockedVersion.Object, package.Version);
        }

        [Test]
        public void PropertyUrl_WhenValidParametersArePassed_ShouldSetTheUrlCorrectly()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();
            mockedVersion.Setup(x => x.Major).Returns(5);
            mockedVersion.Setup(x => x.Minor).Returns(2);
            mockedVersion.Setup(x => x.Patch).Returns(7);
            mockedVersion.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            // act
            var package = new Package(validName, mockedVersion.Object);

            // assert
            Assert.IsTrue(package.Url.Contains("5"));
            Assert.IsTrue(package.Url.Contains("2"));
            Assert.IsTrue(package.Url.Contains("7"));
            Assert.IsTrue(package.Url.Contains("alpha"));
        }

        [Test]
        public void CompareTo_WhenNullValueIsPassed_ShouldThrowArgumentNullExceptionWithMessageContainingNullString()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            var package = new Package(validName, mockedVersion.Object);

            // act and assert
            Assert.That(() => package.CompareTo(null), Throws.ArgumentNullException.With.Message.Contains("null"));
        }        

        [Test]
        public void CompareTo_WhenValidValueIsPassedButWithOtherName_ShouldThrowArgumentException()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            var package = new Package(validName, mockedVersion.Object);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("otherName");

            // act and assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(mockedPackage.Object));
        }

        [Test]
        public void CompareTo_WhenValidValueWithHigherVersionIsPassed_ShouldReturnMinusOne()
        {
            // arrange
            string validName = "validName";

            var mockedVersion = new Mock<IVersion>();
            mockedVersion.Setup(x => x.Major).Returns(5);
            mockedVersion.Setup(x => x.Minor).Returns(2);
            mockedVersion.Setup(x => x.Patch).Returns(7);
            mockedVersion.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package(validName, mockedVersion.Object);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("validName");
            mockedPackage.Setup(x => x.Version.Major).Returns(20);
            mockedPackage.Setup(x => x.Version.Minor).Returns(10);
            mockedPackage.Setup(x => x.Version.Patch).Returns(15);
            mockedPackage.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.beta);

            // act
            var value = package.CompareTo(mockedPackage.Object);

            // assert
            Assert.AreEqual(-1, value);
        }

        [Test]
        public void CompareTo_WhenValidValueWithLowerVersionIsPassed_ShouldReturnOne()
        {
            // arrange
            string validName = "validName";

            var mockedVersion = new Mock<IVersion>();
            mockedVersion.Setup(x => x.Major).Returns(20);
            mockedVersion.Setup(x => x.Minor).Returns(10);
            mockedVersion.Setup(x => x.Patch).Returns(15);
            mockedVersion.Setup(x => x.VersionType).Returns(Enums.VersionType.beta);

            var package = new Package(validName, mockedVersion.Object);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("validName");
            mockedPackage.Setup(x => x.Version.Major).Returns(5);
            mockedPackage.Setup(x => x.Version.Minor).Returns(2);
            mockedPackage.Setup(x => x.Version.Patch).Returns(7);
            mockedPackage.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // act
            var value = package.CompareTo(mockedPackage.Object);

            // assert
            Assert.AreEqual(1, value);
        }

        [Test]
        public void CompareTo_WhenValidValueWithTheSameVersionIsPassed_ShouldReturnZero()
        {
            // arrange
            string validName = "validName";

            var mockedVersion = new Mock<IVersion>();
            mockedVersion.Setup(x => x.Major).Returns(5);
            mockedVersion.Setup(x => x.Minor).Returns(2);
            mockedVersion.Setup(x => x.Patch).Returns(7);
            mockedVersion.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package(validName, mockedVersion.Object);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("validName");
            mockedPackage.Setup(x => x.Version.Major).Returns(5);
            mockedPackage.Setup(x => x.Version.Minor).Returns(2);
            mockedPackage.Setup(x => x.Version.Patch).Returns(7);
            mockedPackage.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // act
            var value = package.CompareTo(mockedPackage.Object);

            // assert
            Assert.AreEqual(0, value);
        }

        [Test]
        public void Equals_WhenNullValueIsPassed_ShouldThrowArgumentNullException()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            var package = new Package(validName, mockedVersion.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void Equals_WhenThePassedObjectIsNotIPackage_ShouldThrowArgumentExceptionWithMessageContainingIPackageString()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            var package = new Package(validName, mockedVersion.Object);
            
            // act and assert
            Assert.That(() => package.Equals(new Object()), Throws.ArgumentException.With.Message.Contains("Package"));
        }

        [Test]
        public void Equals_WhenThePassedObjectIsIPackage_ShouldNotThrow()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();

            var package = new Package(validName, mockedVersion.Object);

            var mockedPackage = new Mock<IPackage>();

            // act and assert
            Assert.DoesNotThrow(() => package.Equals(mockedPackage.Object));
        }

        [Test]
        public void Equals_WhenThePassedObjectIsEqual_ShouldReturnTrue()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();            
            mockedVersion.Setup(x => x.Major).Returns(5);
            mockedVersion.Setup(x => x.Minor).Returns(2);
            mockedVersion.Setup(x => x.Patch).Returns(7);
            mockedVersion.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package(validName, mockedVersion.Object);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("validName");
            mockedPackage.Setup(x => x.Version.Major).Returns(5);
            mockedPackage.Setup(x => x.Version.Minor).Returns(2);
            mockedPackage.Setup(x => x.Version.Patch).Returns(7);
            mockedPackage.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // act
            bool result = package.Equals(mockedPackage.Object);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_WhenThePassedObjectIsNotEqual_ShouldReturnFalse()
        {
            // arrange
            string validName = "validName";
            var mockedVersion = new Mock<IVersion>();
            mockedVersion.Setup(x => x.Major).Returns(5);
            mockedVersion.Setup(x => x.Minor).Returns(2);
            mockedVersion.Setup(x => x.Patch).Returns(7);
            mockedVersion.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package(validName, mockedVersion.Object);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("validName");
            mockedPackage.Setup(x => x.Version.Major).Returns(10);
            mockedPackage.Setup(x => x.Version.Minor).Returns(10);
            mockedPackage.Setup(x => x.Version.Patch).Returns(1);
            mockedPackage.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.beta);

            // act
            bool result = package.Equals(mockedPackage.Object);

            // assert
            Assert.IsFalse(result);
        }
    }
}
