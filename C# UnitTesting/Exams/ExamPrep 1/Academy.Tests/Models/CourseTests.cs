namespace Academy.Tests.Models
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void Constructor_WhenPassedCorrectValues_ShouldCorrectlyAssignPassedValues()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            // act
            var course = new Course(name, lecturesPerWeek, starting, ending);

            // assert
            Assert.AreEqual(course.Name, name);
            Assert.AreEqual(course.LecturesPerWeek, lecturesPerWeek);
            Assert.AreEqual(course.StartingDate, starting);
            Assert.AreEqual(course.EndingDate, ending);
        }

        [Test]
        public void Constructor_WhenPassedCorrectValues_ShouldCorrectlyInitializeTheCollections()
        {
            // arrange
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            // act
            var course = new Course(name, lecturesPerWeek, starting, ending);

            // assert
            Assert.IsNotNull(course.OnlineStudents);
            Assert.IsNotNull(course.OnsiteStudents);
            Assert.IsInstanceOf<List<ILecture>>(course.Lectures);

        }

        [TestCase(null)]
        [TestCase("    ")]
        [TestCase("")]
        public void Name_WhenPassedValueIsIncorrect_ShouldThrowArgumentException(string name)
        {
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            Assert.Throws<ArgumentException>(() => new Course(name, lecturesPerWeek, starting, ending));

        }

        [Test]
        public void Name_WhenPassedValueIsCorrect_ShouldNotThrow()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            Assert.DoesNotThrow(() => new Course(name, lecturesPerWeek, starting, ending));

        }

        [Test]
        public void Name_WhenPassedValueIsCorrect_ShouldAssignCorrectly()
        {
            string name = "validName";
            string anotherName = "anotherValidName";

            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            var course = new Course(name, lecturesPerWeek, starting, ending);

            course.Name = anotherName;

            Assert.AreEqual(course.Name, anotherName);

        }

        [TestCase(0)]
        [TestCase(8)]
        public void LecturesPerWeek_WhenPassedValueIsIncorrect_ShouldThrowArgumentException(int lecturesPerWeek)
        {
            string name = "validName";
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            Assert.Throws<ArgumentException>(() => new Course(name, lecturesPerWeek, starting, ending));

        }

        [Test]
        public void LecturesPerWeek_WhenPassedValueIsCorrect_ShouldNotThrow()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            Assert.DoesNotThrow(() => new Course(name, lecturesPerWeek, starting, ending));
        }

        [Test]
        public void LecturesPerWeek_WhenPassedValueIsCorrect_ShouldAssignCorrectly()
        {
            string name = "validName";

            int lecturesPerWeek = 2;
            int anotherValidLectures = 3;

            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            var course = new Course(name, lecturesPerWeek, starting, ending);

            course.LecturesPerWeek = anotherValidLectures;

            Assert.AreEqual(course.LecturesPerWeek, anotherValidLectures);

        }

        [Test]
        public void StartingDate_WhenPassedValueIsIncorrect_ShouldThrowArgumentException()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime? starting = null;
            DateTime? ending = new DateTime(2018, 1, 8);

            Assert.Throws<ArgumentNullException>(() => new Course(name, lecturesPerWeek, starting, ending));

        }

        [Test]
        public void StartingDate_WhenPassedValueIsCorrect_ShouldNotThrow()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            Assert.DoesNotThrow(() => new Course(name, lecturesPerWeek, starting, ending));
        }

        [Test]
        public void StartingDate_WhenPassedValueIsCorrect_ShouldAssignCorrectly()
        {
            string name = "validName";
            int lecturesPerWeek = 2;

            DateTime starting = new DateTime(2017, 1, 8);
            DateTime newStarting = new DateTime(2017, 2, 9);

            DateTime ending = new DateTime(2018, 1, 8);

            var course = new Course(name, lecturesPerWeek, starting, ending);

            course.StartingDate = newStarting;

            Assert.AreEqual(course.StartingDate, newStarting);

        }

        [Test]
        public void EndingDate_WhenPassedValueIsIncorrect_ShouldThrowArgumentException()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime? starting = new DateTime(2018, 1, 8);
            DateTime? ending = null;

            Assert.Throws<ArgumentNullException>(() => new Course(name, lecturesPerWeek, starting, ending));

        }

        [Test]
        public void EndingDate_WhenPassedValueIsCorrect_ShouldNotThrow()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            Assert.DoesNotThrow(() => new Course(name, lecturesPerWeek, starting, ending));
        }

        [Test]
        public void EndingDate_WhenPassedValueIsCorrect_ShouldAssignCorrectly()
        {
            string name = "validName";
            int lecturesPerWeek = 2;

            DateTime starting = new DateTime(2017, 1, 8);

            DateTime ending = new DateTime(2018, 1, 8);
            DateTime newEnding = new DateTime(2017, 2, 9);

            var course = new Course(name, lecturesPerWeek, starting, ending);

            course.EndingDate = newEnding;

            Assert.AreEqual(course.EndingDate, newEnding);

        }

        [Test]
        public void ToString_WhenPassedDataIsCorrect_ShouldReturnPassedDataAListOfLectures()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            var lecture = new Mock<ILecture>();
            lecture.Setup(x => x.ToString());

            var course = new Course(name, lecturesPerWeek, starting, ending);
            course.Lectures.Add(lecture.Object);

            course.ToString();

            lecture.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ToString_WhenThereIsNoLectures_ShouldReturnPassedDataAndCorrectMessage()
        {
            string name = "validName";
            int lecturesPerWeek = 2;
            DateTime starting = new DateTime(2017, 1, 8);
            DateTime ending = new DateTime(2018, 1, 8);

            var course = new Course(name, lecturesPerWeek, starting, ending);

            StringAssert.Contains("no lectures", course.ToString());
        }
    }
}
