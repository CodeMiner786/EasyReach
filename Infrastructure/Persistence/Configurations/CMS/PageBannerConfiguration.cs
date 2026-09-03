using EasyReach_Domain.Entities.CMSs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Persistence.Configurations.CMS
{
    public class PageBannerConfiguration : IEntityTypeConfiguration<PageBanner>
    {
        public void Configure(EntityTypeBuilder<PageBanner> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Page)
                .WithMany(x => x.PageBanners)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Banner)
                .WithMany()
                .HasForeignKey(x => x.BannerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
