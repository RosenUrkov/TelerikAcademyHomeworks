using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentsAndCourses
{
    public class Course
    {
        private IList<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public Course(IEnumerable<Student> students)
        {           
            this.students = new List<Student>(students);
            CheckStudentsInCourse();
        }

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
            private set
            {
                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {            
            this.students.Add(student);
            CheckStudentsInCourse();
        }

        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }

        private void CheckStudentsInCourse()
        {
            if (this.students.Count >= 30)
            {
                throw new ArgumentException("Students in a course must be less than 30");
            }
        }
    }
}
