namespace SampleApp.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SampleApp.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SampleApp.Data.SampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SampleApp.Data.SampleDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(SampleDbContext context)
        {
            const string AdministratorUserName = "fake@email.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
