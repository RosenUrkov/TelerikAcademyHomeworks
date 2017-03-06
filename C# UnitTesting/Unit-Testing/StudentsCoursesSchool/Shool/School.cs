using System.Collections.Generic;

namespace StudentsAndCourses
{
    public class School
    {
        private IList<Course> courses;

        public School()
        {
            this.courses = new List<Course>();
        }

        public School(IEnumerable<Course> courses)
        {
            this.courses = new List<Course>(courses);       
        }

        public IList<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
            private set
            {
                this.courses = value;
            }
        }

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            this.courses.Remove(course);
        }
    }
}
