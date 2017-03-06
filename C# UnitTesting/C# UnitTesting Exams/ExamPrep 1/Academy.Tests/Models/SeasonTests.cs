namespace Academy.Tests.Models
{
    using NUnit.Framework;
    using Moq;
    using Ploeh.AutoFixture;
    using Academy.Models;
    using Academy.Models.Contracts;

    [TestFixture]
    public class SeasonTests
    {
        [Test]
        public void ListUsers_WhenPresentInSeason_ShouldReturnAListOfStudentsAndTrainers()
        {
            var season = new Season(2016, 2017, Academy.Models.Enums.Initiative.CoderDojo);
            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(x => x.ToString()).Verifiable();
            var mockedTrainer = new Mock<ITrainer>();
            mockedTrainer.Setup(x => x.ToString()).Verifiable();
            
            season.Students.Add(mockedStudent.Object);
            season.Trainers.Add(mockedTrainer.Object);

            season.ListUsers();

            mockedStudent.Verify();
            mockedTrainer.Verify();
        }

        [Test]
        public void ListUsers_WhenPresentInSeasonAndNoUsers_ShouldReturnMessageSayingThereIsNoUsersInTheSeason()
        {
            var season = new Season(2016, 2017, Academy.Models.Enums.Initiative.CoderDojo);

            StringAssert.Contains("no users", season.ListUsers().ToString());
            
        }

        [Test]
        public void ListCourses_WhenPresentInSeason_ShouldReturnAListOfCourses()
        {
            var season = new Season(2016, 2017, Academy.Models.Enums.Initiative.CoderDojo);
            var mockedCourse = new Mock<ICourse>();
            mockedCourse.Setup(x => x.ToString()).Verifiable();

            season.Courses.Add(mockedCourse.Object);

            season.ListCourses();

            mockedCourse.Verify();
        }

        [Test]
        public void ListCourses_WhenPresentInSeasonAndNoUsers_ShouldReturnMessageSayingThereIsNoCoursesInThisSeason()
        {
            var season = new Season(2016, 2017, Academy.Models.Enums.Initiative.CoderDojo);

            StringAssert.Contains("no courses", season.ListCourses().ToString());

        }
    }
}
