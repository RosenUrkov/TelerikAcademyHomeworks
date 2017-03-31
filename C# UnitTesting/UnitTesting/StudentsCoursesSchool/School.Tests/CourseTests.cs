namespace School.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using StudentsAndCourses;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class CourseTests
    {
        private static IList<Student> students;

        [TestInitialize]
        public void TestInitialize()
        {
            students = new List<Student>() { new Student("Ivan"), new Student("Pesho"), new Student("Gosho") };
        }

        [TestMethod]
        public void Course_AddStudent_ShouldAddCorrectly()
        {
            var course = new Course(students);
            int oldStudentCount = course.Students.Count;

            course.AddStudent(new Student("Gospodin"));
            int newStudentCount = course.Students.Count;

            Assert.AreEqual(oldStudentCount+1, newStudentCount);
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldRemoveCorrectly()
        {
            var course = new Course(students);
            var student = course.Students[0];
            int oldStudentCount = course.Students.Count;

            course.RemoveStudent(student);
            int newStudentCount = course.Students.Count;

            Assert.AreEqual(oldStudentCount -1, newStudentCount);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void Course_AddingMoreThan29Students_ShouldThrowException()
        {
            var course = new Course(new List<Student>
            { new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho"), new Student("Gosho"),
             new Student("Ivan"), new Student("Pesho")
            });

            ThrowsAssert.Throws<ArgumentException>(() => course.AddStudent(new Student("Mitko")));        
        }
    }
}
