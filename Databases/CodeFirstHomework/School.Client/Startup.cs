namespace School.Client
{
    using School.Data;
    using School.Models;
    using System.Data.Entity;
    using School.Data.Migrations;
    using System.Linq;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Configuration>());

            using (var context = new SchoolContext())
            {
                context.Students.ToList();
            }
        }
    }
}
