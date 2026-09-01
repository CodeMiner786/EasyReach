using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Infrastructure.Persistence.Configurations.CMS
{
    /// <summary>
    /// FaqItem entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class FaqItemConfiguration : IEntityTypeConfiguration<FaqItem>
    {
        public void Configure(EntityTypeBuilder<FaqItem> builder)
        {
            builder.ToTable("FaqItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Question).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(2000);
        }
    }
}
