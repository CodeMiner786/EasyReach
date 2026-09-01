using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Promotions;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Infrastructure.Persistence.Configurations.Promotions
{
    /// <summary>
    /// ComboItem entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class ComboItemConfiguration : IEntityTypeConfiguration<ComboItem>
    {
        public void Configure(EntityTypeBuilder<ComboItem> builder)
        {
            builder.ToTable("ComboItems");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.ComboId, x.ProductVariantId }).IsUnique();

            builder.HasOne(x => x.Combo)
                .WithMany(p => p.Items)
                .HasForeignKey(x => x.ComboId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ProductVariant)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
