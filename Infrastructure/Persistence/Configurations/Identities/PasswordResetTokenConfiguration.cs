using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Infrastructure.Persistence.Configurations.Identities
{
    /// <summary>
    /// PasswordResetToken entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class PasswordResetTokenConfiguration : IEntityTypeConfiguration<PasswordResetToken>
    {
        public void Configure(EntityTypeBuilder<PasswordResetToken> builder)
        {
            builder.ToTable("PasswordResetTokens");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.RequestedByIp).HasMaxLength(45);

            builder.HasIndex(x => x.Token).IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(p => p.PasswordResetTokens)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
