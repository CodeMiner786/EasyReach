using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Infrastructure.Persistence.Configurations.Orders
{
    /// <summary>
    /// Order entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CustomerNote).HasMaxLength(1000);

            builder.Property(x => x.SubTotal).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DiscountAmount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ShippingCharge).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GrandTotal).HasColumnType("decimal(18,2)");

            builder.HasIndex(x => x.OrderNumber).IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ShippingAddress)
                .WithMany()
                .HasForeignKey(x => x.ShippingAddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.ProcessedByUserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
