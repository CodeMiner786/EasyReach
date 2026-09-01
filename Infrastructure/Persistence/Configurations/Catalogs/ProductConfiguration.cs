using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Infrastructure.Persistence.Configurations.Catalogs
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SKU).IsRequired().HasMaxLength(200);

            // Category Relationship (Required)
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Brand Relationship (Optional / Nullable)
            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandId)
                .IsRequired(false) // 👈 ব্র্যান্ড না থাকলে ডাটাবেজে NULL সেভ হবে
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(x => x.SKU).IsUnique();
            builder.HasIndex(x => x.Slug).IsUnique();
        }
    }
}
