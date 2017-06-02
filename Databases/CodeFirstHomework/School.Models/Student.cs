namespace School.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();

            this.Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
