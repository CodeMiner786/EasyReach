using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Infrastructure.Persistence.Configurations.CMS
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Content).IsRequired();

            builder.HasIndex(x => x.Slug).IsUnique();

            // নতুন যুক্ত হওয়া রিলেশনশিপ কনফিগারেশন
            builder.HasMany(x => x.PageBanners)
                .WithOne(x => x.Page)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PageProducts)
                .WithOne(x => x.Page)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
