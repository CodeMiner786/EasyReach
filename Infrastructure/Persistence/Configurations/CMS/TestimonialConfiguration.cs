using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Infrastructure.Persistence.Configurations.CMS
{
    /// <summary>
    /// Testimonial entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Occupation).HasMaxLength(200);
            builder.Property(x => x.ImageUrl).HasMaxLength(500);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(2000);
        }
    }
}
