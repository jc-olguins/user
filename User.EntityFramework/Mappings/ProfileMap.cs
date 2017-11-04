using System.Data.Entity.ModelConfiguration;
using User.Entities;

namespace User.EntityFramework.Mappings
{
    public class ProfileMap : EntityTypeConfiguration<Profile>
    {
        public ProfileMap()
        {
            HasKey(p => p.Id).ToTable("AspNetProfiles");
            HasRequired(p => p.ApplicationUser).WithOptional(p => p.Profile).WillCascadeOnDelete();
            Property(p => p.Id).HasMaxLength(128);
            Property(p => p.FirstName).HasMaxLength(200).IsRequired();
            Property(p => p.LastName).HasMaxLength(200).IsRequired();
        }
    }
}
