using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using User.Entities;
using User.EntityFramework.Mappings;

namespace User.EntityFramework
{

    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("proyecto", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProfileMap());
         
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
