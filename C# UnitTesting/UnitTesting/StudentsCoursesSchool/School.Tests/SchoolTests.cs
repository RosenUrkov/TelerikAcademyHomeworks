namespace School.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsAndCourses;
    using System.Collections.Generic;

    [TestClass]
    public class ShoolTests
    {
        private ICollection<Course> courses;
        private School mySchool;

        [TestInitialize]
        public void TestInitialize()
        {
            mySchool = new School(); //for code coverige
            courses = new List<Course>() { new Course(), new Course(new List<Student>() {new Student("Ivan")})
                , new Course(new List<Student>() {new Student("Petko"), new Student("Kristiqn")}) };
        }

        [TestMethod]
        public void School_AddCourse_ShouldAddCorrectly()
        {
            var school = new School(courses);
            int oldCourseCount = school.Courses.Count;

            school.AddCourse(new Course());
            int newCourseCount = school.Courses.Count;

            Assert.AreEqual(oldCourseCount + 1, newCourseCount);
        }

        [TestMethod]
        public void Shcool_RemoveCourse_ShouldRemoveCorrectly()
        {
            var school = new School(courses);
            var course = school.Courses[0];
            int oldCourseCount = school.Courses.Count;

            school.RemoveCourse(course);
            int newCourseCount = school.Courses.Count;

            Assert.AreEqual(oldCourseCount - 1, newCourseCount);
        }
    }
}
