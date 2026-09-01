using EasyReach_Domain.Entities.LandingPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyReach_Infrastructure.Persistence.Configurations.LandingPages
{
    public class LandingPageConfiguration : IEntityTypeConfiguration<LandingPage>
    {
        public void Configure(EntityTypeBuilder<LandingPage> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Slug).IsUnique();

            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(200);
            builder.Property(p => p.OfferPrice).HasColumnType("decimal(18,2)");
        }
    }
}
