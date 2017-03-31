using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsAndCourses;

namespace School.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_SetName_ShouldThrowException()
        {
            var student = new Student(null);                       
        }

        [TestMethod]
        public void Student_SetName_ShouldWorkCorrectly()
        {
            var student = new Student("Pesho");

            Assert.IsNotNull(student.Name);
        }

        [TestMethod]
        public void Student_UniqueNumber_ShouldBeUnique()
        {
            var student = new Student("Pesho");
            var secondStudent = new Student("Gosho");

            Assert.AreNotEqual(student.UniqueNumber, secondStudent.UniqueNumber);
        }
    }
}
