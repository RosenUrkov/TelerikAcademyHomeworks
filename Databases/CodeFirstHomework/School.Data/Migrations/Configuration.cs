namespace School.Data.Migrations
{
    using School.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            context.Students.AddOrUpdate(student => student.FirstName,
                new Student()
                {
                    FirstName = "Pesho",
                    LastName = "Peshov",
                    Number = 5,
                    City = new City()
                    {
                        Name = "Sofia"
                    }
                });

            context.Courses.AddOrUpdate(course => course.Name,
                new Course()
                {
                    Name = "Databases",
                    City = new City()
                    {
                        Name = "Plovdiv"
                    }
                });
        }
    }
}
