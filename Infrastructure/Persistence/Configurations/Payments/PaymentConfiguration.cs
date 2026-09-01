using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Payments;
using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Infrastructure.Persistence.Configurations.Payments
{
    // Payment entity er EF Core Fluent API configuration - table name,
    // column constraint (required/max length), decimal precision, unique
    // index, ar relationship/delete-behavior shob ekhane define kora.
    // ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    // diye eta automatic detect + apply hoy.

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TransactionId).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.TransactionId).IsUnique();

            builder.Property(x => x.ValidationId).HasMaxLength(100);
            builder.Property(x => x.BankTransactionId).HasMaxLength(100);
            builder.Property(x => x.CardType).HasMaxLength(100);
            builder.Property(x => x.CardIssuer).HasMaxLength(100);
            builder.Property(x => x.CardBrand).HasMaxLength(100);
            builder.Property(x => x.GatewayResponse).HasMaxLength(4000);

            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.StoreAmount).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
