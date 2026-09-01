using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Infrastructure.Persistence.Configurations.Promotions
{
    /// <summary>
    /// Combo entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class ComboConfiguration : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.ToTable("Combos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ImageUrl).HasMaxLength(500);

            builder.Property(x => x.ComboPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.RegularPrice).HasColumnType("decimal(18,2)");

            builder.HasIndex(x => x.Slug).IsUnique();
        }
    }
}
