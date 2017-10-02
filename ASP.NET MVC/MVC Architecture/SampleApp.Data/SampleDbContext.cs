using Microsoft.AspNet.Identity.EntityFramework;
using SampleApp.Data.Models;
using SampleApp.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data
{
    public class SampleDbContext : IdentityDbContext<User>
    {
        public SampleDbContext() : base("SampleDbConnection")
        {
        }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Video> Videos { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("IdentityUsers").Property(p => p.Id).HasColumnName("Id");
            //modelBuilder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
