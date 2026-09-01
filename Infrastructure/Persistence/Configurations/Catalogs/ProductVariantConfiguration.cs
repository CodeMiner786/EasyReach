using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Infrastructure.Persistence.Configurations.Catalogs
{
    /// <summary>
    /// ProductVariant entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.VariantName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SKU).IsRequired().HasMaxLength(100);

            builder.Property(x => x.RegularPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DiscountPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.WeightOrVolume).HasColumnType("decimal(10,3)");

            builder.HasIndex(x => x.SKU).IsUnique();

            builder.HasOne(x => x.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
