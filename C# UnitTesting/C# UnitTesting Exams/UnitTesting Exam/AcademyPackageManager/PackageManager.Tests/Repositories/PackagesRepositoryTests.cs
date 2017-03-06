namespace PackageManager.Tests.Repositories
{
    using NUnit.Framework;
    using Moq;
    using Info.Contracts;
    using PackageManager.Models.Contracts;
    using System.Collections.Generic;
    using PackageManager.Repositories;
    using Models.Mocks;
    using System;

    [TestFixture]
    public class PackagesRepositoryTests
    {
        [Test]
        public void Add_PackageValueIsNull_ShouldThrowArgumentNullExceptionWithMessageContainingPackageString()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act and assert
            Assert.That(() => packageRepository.Add(null), Throws.ArgumentNullException.With.Message.Contains("package"));
        }

        [Test]
        public void Add_ThereIsNoSuchPackageInThePackages_ShouldAddThePackageCorrectly()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");

            // act
            packageRepository.Add(mockedPackage.Object);

            // assert
            Assert.IsTrue(mockedPackagesList.Contains(mockedPackage.Object));
        }

        [Test]
        public void Add_ThisPackageAlredyExistInThePackagesWithTheSameVersion_ShouldCallLogMethodThreeTimes()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            mockedLogger.Setup(x => x.Log(It.IsAny<string>()));

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);
            
            var mockedPackagesList = new List<IPackage>();
            mockedPackagesList.Add(mockedPackage.Object);

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);           

            // act
            packageRepository.Add(mockedPackage.Object);

            // assert
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void Add_ThisPackageAlredyExistInThePackagesButIsLowerVersion_ShouldCallUpdateMethod()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            mockedLogger.Setup(x => x.Log(It.IsAny<string>()));

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var anotherMockedPackage = new Mock<IPackage>();
            anotherMockedPackage.Setup(x => x.Name).Returns("name");

            var mockedPackagesList = new List<IPackage>();
            mockedPackagesList.Add(anotherMockedPackage.Object);

            var packageRepository = new FakePackageRepository(mockedLogger.Object, mockedPackagesList);

            // act
            packageRepository.Add(mockedPackage.Object);

            // assert
            Assert.IsTrue(packageRepository.IsCalled);
        }

        [Test]
        public void Add_ThisPackageAlredyExistInThePackagesButIsLowerVersion_ShouldGetTheNewPackageVersion()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            mockedLogger.Setup(x => x.Log(It.IsAny<string>()));

            var mockedVersion = new Mock<IVersion>();

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);
            mockedPackage.Setup(x => x.Version).Returns(mockedVersion.Object);

            var anotherMockedPackage = new Mock<IPackage>();
            anotherMockedPackage.Setup(x => x.Name).Returns("name");
            anotherMockedPackage.SetupSet(x => x.Version = It.Is<IVersion>(y=>y==mockedVersion.Object));

            var mockedPackagesList = new List<IPackage>();
            mockedPackagesList.Add(anotherMockedPackage.Object);

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act
            packageRepository.Add(mockedPackage.Object);

            // assert
            anotherMockedPackage.VerifySet((x => x.Version = It.Is<IVersion>(y => y == mockedVersion.Object)),Times.Once);
        }

        [Test]
        public void Add_ThisPackageAlredyExistInThePackagesButIsHigherVersion_ShouldCallLogMethodTwoTimes()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            mockedLogger.Setup(x => x.Log(It.IsAny<string>()));
            
            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            var anotherMockedPackage = new Mock<IPackage>();
            anotherMockedPackage.Setup(x => x.Name).Returns("name");

            var mockedPackagesList = new List<IPackage>();
            mockedPackagesList.Add(anotherMockedPackage.Object);

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act
            packageRepository.Add(mockedPackage.Object);

            // assert
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void Delete_PackageValueIsNull_ShouldThrowArgumentNullExceptionWithMessageContainingPackageString()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act and assert
            Assert.That(() => packageRepository.Delete(null), Throws.ArgumentNullException.With.Message.Contains("Package"));
        }

        [Test]
        public void Delete_ThereIsNoSuchPackageInThePackages_ShouldThrowArgumentNullException()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");

            // act and assert
            Assert.Throws<ArgumentNullException>(()=> packageRepository.Delete(mockedPackage.Object));           

        }

        [Test]
        public void Delete_ThePackageIsThereButIsADependency_ShouldCallLogMethodThreeTimes()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            mockedLogger.Setup(x => x.Log(It.IsAny<string>()));
            
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            
            var mockedPackage = new Mock<IPackage>();
            var mockedDependencyList = new List<IPackage>() { mockedPackage.Object };
            
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.Dependencies).Returns(mockedDependencyList);
            mockedPackage.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);

            mockedPackagesList.Add(mockedPackage.Object);

            // act
            packageRepository.Delete(mockedPackage.Object);

            // assert
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()),Times.Exactly(3));
        }

        [Test]
        public void Delete_ThePackageIsThereAndIsNotADependency_ShouldReturnTheDeletedPackage()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();

            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            var emptyDependenciesList = new List<IPackage>();

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.Dependencies).Returns(emptyDependenciesList);
            mockedPackage.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);

            mockedPackagesList.Add(mockedPackage.Object);

            // act
            var deleted = packageRepository.Delete(mockedPackage.Object);

            // assert
            Assert.AreSame(deleted, mockedPackage.Object);
        }

        [Test]
        public void Update_PackageValueIsNull_ShouldThrowArgumentNullExceptionWithMessageContainingPackageString()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act and assert
            Assert.That(() => packageRepository.Update(null), Throws.ArgumentNullException.With.Message.Contains("package"));
        }

        [Test]
        public void Update_ThereIsNoSuchPackageInThePackages_ShouldThrowArgumentNullException()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");

            // act and assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Update(mockedPackage.Object));

        }

        [Test]
        public void Update_ThereIsLowerVersionOfThatPackage_ShouldUpdateTheExistingPackageVersion()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var mockedVersion = new Mock<IVersion>();

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);
            mockedPackage.Setup(x => x.Version).Returns(mockedVersion.Object);

            var anotherMockedPackage = new Mock<IPackage>();
            anotherMockedPackage.Setup(x => x.Name).Returns("name");
            anotherMockedPackage.SetupSet(x => x.Version = It.Is<IVersion>(y => y == mockedVersion.Object));

            mockedPackagesList.Add(anotherMockedPackage.Object);

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act 
            packageRepository.Update(mockedPackage.Object);

            // assert
            anotherMockedPackage.VerifySet((x => x.Version = It.Is<IVersion>(y => y == mockedVersion.Object)),Times.Once);
        }

        [Test]
        public void Update_ThereIsHigherVersionOfThatPackage_ShouldThrowArgumentException()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var mockedVersion = new Mock<IVersion>();

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);
            mockedPackage.Setup(x => x.Version).Returns(mockedVersion.Object);

            var anotherMockedPackage = new Mock<IPackage>();
            anotherMockedPackage.Setup(x => x.Name).Returns("name");
            anotherMockedPackage.SetupSet(x => x.Version = It.Is<IVersion>(y => y == mockedVersion.Object));

            mockedPackagesList.Add(anotherMockedPackage.Object);

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act and assert
            Assert.Throws<ArgumentException>(()=>packageRepository.Update(mockedPackage.Object));
            
        }

        [Test]
        public void Update_ThereIsSameVersionOfThatPackage_ShouldReturnFalse()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var mockedVersion = new Mock<IVersion>();

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);
            mockedPackage.Setup(x => x.Version).Returns(mockedVersion.Object);

            var anotherMockedPackage = new Mock<IPackage>();
            anotherMockedPackage.Setup(x => x.Name).Returns("name");
            anotherMockedPackage.SetupSet(x => x.Version = It.Is<IVersion>(y => y == mockedVersion.Object));

            mockedPackagesList.Add(anotherMockedPackage.Object);

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act 
            var isUpdated = packageRepository.Update(mockedPackage.Object);

            // assert
            Assert.IsFalse(isUpdated);
        }

        [Test]
        public void GetAll_WhenThereIsNoPassedCollection_ShouldReturnEmptyCollection()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            // act
            var packages = (List<IPackage>)packageRepository.GetAll();

            // assert
            Assert.IsTrue(packages.Count == 0);
        }

        [Test]
        public void GetAll_WhenThereIsPassedCollectionAsParameter_ShouldReturnCollectionWithEqualNumberOfElements()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedPackagesList = new List<IPackage>();

            var packageRepository = new PackageRepository(mockedLogger.Object, mockedPackagesList);

            var mockedPackage = new Mock<IPackage>();
            var anotherMockedPackage = new Mock<IPackage>();

            mockedPackagesList.Add(mockedPackage.Object);
            mockedPackagesList.Add(anotherMockedPackage.Object);
            
            // act
            var packages = (List<IPackage>)packageRepository.GetAll();

            // assert
            Assert.IsTrue(packages.Count == 2);
        }
    }
}
