using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Infrastructure.Persistence.Configurations.Identities
{
    /// <summary>
    /// AdminActivityLog entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class AdminActivityLogConfiguration : IEntityTypeConfiguration<AdminActivityLog>
    {
        public void Configure(EntityTypeBuilder<AdminActivityLog> builder)
        {
            builder.ToTable("AdminActivityLogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.AffectedEntityId).HasMaxLength(200);
            builder.Property(x => x.IpAddress).HasMaxLength(45);

            builder.HasOne(x => x.User)
                .WithMany(p => p.ActivityLogs)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
