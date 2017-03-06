namespace PackageManager.Tests.Commands
{
    using NUnit.Framework;
    using Moq;
    using PackageManager.Models.Contracts;
    using Mocks;
    using Enums;
    using PackageManager.Core.Contracts;

    [TestFixture]
    public class InstallCommandTests
    {
        [Test]
        public void Constructor_WhenPassedValuesAreCorrect_ShouldSetTheInstallerProperly()
        {
            // arrange
            var mockedInstaller = new Mock<IInstaller<IPackage>>();
            mockedInstaller.Setup(x => x.Operation);

            var mockedPackage = new Mock<IPackage>();

            // act
            var installCommand = new FakeInstallCommand(mockedInstaller.Object, mockedPackage.Object);

            // assert
            Assert.IsInstanceOf<IInstaller<IPackage>>(installCommand.GetInstaller());
        }

        [Test]
        public void Constructor_WhenPassedValuesAreCorrect_ShouldSetThePackageProperly()
        {
            // arrange
            var mockedInstaller = new Mock<IInstaller<IPackage>>();
            mockedInstaller.Setup(x => x.Operation);

            var mockedPackage = new Mock<IPackage>();

            // act
            var installCommand = new FakeInstallCommand(mockedInstaller.Object, mockedPackage.Object);

            // assert
            Assert.IsInstanceOf<IPackage>(installCommand.GetPackage());

        }

        [Test]
        public void InstallerFiled_WhenPassedValuesAreCorrect_ShouldSetTheInstallerProperly()
        {
            // arrange
            var mockedInstaller = new Mock<IInstaller<IPackage>>();
            mockedInstaller.Setup(x => x.Operation);

            var mockedPackage = new Mock<IPackage>();

            // act
            var installCommand = new FakeInstallCommand(mockedInstaller.Object, mockedPackage.Object);

            // assert
            Assert.AreSame(mockedInstaller.Object, installCommand.GetInstaller());
        }

        [Test]
        public void PackageField_WhenPassedValuesAreCorrect_ShouldSetThePackageProperly()
        {
            // arrange
            var mockedInstaller = new Mock<IInstaller<IPackage>>();
            mockedInstaller.Setup(x => x.Operation);

            var mockedPackage = new Mock<IPackage>();

            // act
            var installCommand = new FakeInstallCommand(mockedInstaller.Object, mockedPackage.Object);

            // assert
            Assert.AreSame(mockedPackage.Object, installCommand.GetPackage());
        }

        [Test]
        public void InstallerOperationProperty_WhenPassedValuesAreCorrect_ShouldSetCorrectValue()
        {
            // arrange
            var mockedInstaller = new Mock<IInstaller<IPackage>>();
            mockedInstaller.SetupSet(x => x.Operation=It.Is<InstallerOperation>(y=> y==InstallerOperation.Install));

            var mockedPackage = new Mock<IPackage>();

            // act
            var installCommand = new FakeInstallCommand(mockedInstaller.Object, mockedPackage.Object);

            // assert
            mockedInstaller.VerifySet((x => x.Operation = It.Is<InstallerOperation>(y => y == InstallerOperation.Install)),Times.Once);
        }

        [Test]
        public void Execute_WhenEvrythingIsCorrect_ShouldCallPreformOperationMethodOnTheInstaller()
        {
            // arrange
            var mockedPackage = new Mock<IPackage>();
            
            var mockedInstaller = new Mock<IInstaller<IPackage>>();
            mockedInstaller.Setup(x => x.Operation);
            mockedInstaller.Setup(x => x.PerformOperation(It.Is<IPackage>(y => y == mockedInstaller.Object)));

            var installCommand = new FakeInstallCommand(mockedInstaller.Object, mockedPackage.Object);

            // act
            installCommand.Execute();

            // assert
            mockedInstaller.Verify((x => x.PerformOperation(It.Is<IPackage>(y => y == mockedPackage.Object))),Times.Once);
        }
    }
}
