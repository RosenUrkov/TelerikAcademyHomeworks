namespace PackageManager.Tests.Models
{
    using Info;
    using NUnit.Framework;
    using PackageManager.Models;
    using Repositories;
    using Moq;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using PackageManager.Repositories.Contracts;

    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Constructor_WhenPackageRepositoryIsNotPassed_ShouldSetTheFieldCorrectlyWithTheDefaultParameter()
        {
            // arrange
            string validName = "validName";
            string validLocation = "validLocation";

            // act
            var project = new Project(validName, validLocation);

            // assert
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void Constructor_WhenPackageRepositoryIsPassed_ShouldSetTheFieldCorrectlyWithThePassedParameter()
        {
            // arrange
            string validName = "validName";
            string validLocation = "validLocation";
            var mockedRepository = new Mock<IRepository<IPackage>>();

            // act
            var project = new Project(validName, validLocation, mockedRepository.Object);

            // assert
            Assert.AreSame(mockedRepository.Object, project.PackageRepository);
        }

        [Test]
        public void PropertyName_WhenValidParametersArePassed_ShouldSetCorrectlyTheName()
        {
            // arrange
            string validName = "validName";
            string validLocation = "validLocation";

            // act
            var project = new Project(validName, validLocation);

            // assert
            Assert.AreEqual(validName, project.Name);
        }

        [Test]
        public void PropertyLocation_WhenValidParametersArePassed_ShouldSetCorrectlyTheLocation()
        {
            // arrange
            string validName = "validName";
            string validLocation = "validLocation";

            // act
            var project = new Project(validName, validLocation);

            // assert
            Assert.AreEqual(validLocation, project.Location);
        }
    }
}
