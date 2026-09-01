using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Infrastructure.Persistence.Configurations.Orders
{
    /// <summary>
    /// OrderItem entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductNameSnapshot).IsRequired().HasMaxLength(200);
            builder.Property(x => x.VariantNameSnapshot).IsRequired().HasMaxLength(200);

            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Order)
                .WithMany(p => p.Items)
                .HasForeignKey(x => x.OrderId)
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
