namespace School.Models
{
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            this.Materials = new HashSet<Material>();

            this.Students = new HashSet<Student>();

            this.Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Course ParentCourse { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
