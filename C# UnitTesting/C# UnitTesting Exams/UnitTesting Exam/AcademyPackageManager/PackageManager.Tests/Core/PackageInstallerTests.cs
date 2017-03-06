namespace PackageManager.Tests.Core
{
    using NUnit.Framework;
    using Moq;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using System.Collections.Generic;
    using PackageManager.Core;
    using PackageManager.Repositories.Contracts;

    [TestFixture]
    public class PackageInstallerTests
    {
        [Test]
        public void Constructor_WhenPassedParametersAreCorrect_ShouldCallRestorePackagesMethod()
        {
            // arrange :)
            var mockedDownloader = new Mock<IDownloader>();
            mockedDownloader.Setup(x => x.Location);
            mockedDownloader.Setup(x => x.Remove(It.Is<string>(y=>y=="name")));
            mockedDownloader.Setup(x => x.Download(It.IsAny<string>()));

            var emptyMockedDependenciesList = new List<IPackage>();

            var mockedDependencyPackage = new Mock<IPackage>();
            mockedDependencyPackage.Setup(x => x.Name).Returns("name");
            mockedDependencyPackage.Setup(x => x.Dependencies).Returns(emptyMockedDependenciesList);

            var filledMockedDependenciesList = new List<IPackage>() { mockedDependencyPackage.Object};

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.Dependencies).Returns(filledMockedDependenciesList);

            var mockedPackagesList = new List<IPackage>() { mockedPackage.Object };

            var mockedRepository = new Mock<IRepository<IPackage>>();
            mockedRepository.Setup(x => x.GetAll()).Returns(mockedPackagesList);
            mockedRepository.Setup(x => x.Add(It.Is<IPackage>(y => y == mockedPackage.Object)));

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.PackageRepository).Returns(mockedRepository.Object);

            // act
            var packageInstaller = new PackageInstaller(mockedDownloader.Object, mockedProject.Object);

            // assert
            mockedDependencyPackage.Verify((x => x.Dependencies), Times.Once);
        }

        [Test]
        public void PreformOperation_WithInstallCommandAndEmptyDependenciesList_ShouldCallTwoTimesDownloadAndOneTimeRemove()
        {
            // arrange
            var mockedDownloader = new Mock<IDownloader>();
            mockedDownloader.Setup(x => x.Location);
            mockedDownloader.Setup(x => x.Remove(It.Is<string>(y => y == "name")));
            mockedDownloader.Setup(x => x.Download(It.IsAny<string>()));          
            
            var mockedPackagesList = new List<IPackage>() { };

            var mockedRepository = new Mock<IRepository<IPackage>>();
            mockedRepository.Setup(x => x.GetAll()).Returns(mockedPackagesList);
            mockedRepository.Setup(x => x.Add(It.IsAny<IPackage>()));

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.PackageRepository).Returns(mockedRepository.Object);

            var packageInstaller = new PackageInstaller(mockedDownloader.Object, mockedProject.Object);

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.Dependencies).Returns(mockedPackagesList);

            // act
            packageInstaller.PerformOperation(mockedPackage.Object);

            // assert
            mockedDownloader.Verify(x => x.Remove(It.Is<string>(y => y == "name")),Times.Once);
            mockedDownloader.Verify(x => x.Download(It.IsAny<string>()),Times.Exactly(2));

        }

        [Test]
        public void PreformOperation_WithInstallCommandAndOneDependencyInDependenciesList_ShouldCallFourTimesDownloadAndTwoTimeRemove()
        {
            // arrange
            var mockedDownloader = new Mock<IDownloader>();
            mockedDownloader.Setup(x => x.Location);
            mockedDownloader.Setup(x => x.Remove(It.Is<string>(y => y == "name")));
            mockedDownloader.Setup(x => x.Download(It.IsAny<string>()));

            var mockedPackagesList = new List<IPackage>() { };

            var mockedRepository = new Mock<IRepository<IPackage>>();
            mockedRepository.Setup(x => x.GetAll()).Returns(mockedPackagesList);
            mockedRepository.Setup(x => x.Add(It.IsAny<IPackage>()));

            var mockedProject = new Mock<IProject>();
            mockedProject.Setup(x => x.PackageRepository).Returns(mockedRepository.Object);

            var packageInstaller = new PackageInstaller(mockedDownloader.Object, mockedProject.Object);

            var mockedDependencyPackage = new Mock<IPackage>();
            mockedDependencyPackage.Setup(x => x.Name).Returns("name");
            mockedDependencyPackage.Setup(x => x.Dependencies).Returns(mockedPackagesList);

            var mockedDependencyPackagesList = new List<IPackage>() { mockedDependencyPackage.Object};

            var mockedPackage = new Mock<IPackage>();
            mockedPackage.Setup(x => x.Name).Returns("name");
            mockedPackage.Setup(x => x.Dependencies).Returns(mockedDependencyPackagesList);

            // act
            packageInstaller.PerformOperation(mockedPackage.Object);

            // assert
            mockedDownloader.Verify(x => x.Remove(It.Is<string>(y => y == "name")), Times.Exactly(2));
            mockedDownloader.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(4));

        }

    }
}
