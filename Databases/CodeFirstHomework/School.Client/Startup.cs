namespace School.Client
{
    using School.Data;
    using School.Models;
    using System.Data.Entity;
    using School.Data.Migrations;

    public class Startup
    {
        public static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Configuration>());

            var context = new SchoolContext();

            context.Students.Add(new Student() { Name = "Ivan" });
            context.SaveChanges();
        }
    }
}
