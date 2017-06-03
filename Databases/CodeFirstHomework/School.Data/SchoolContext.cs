namespace School.Data
{
    using School.Models;
    using System.Data.Entity;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("StudentSystem")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public IDbSet<City> Cities { get; set; }
    }
}
