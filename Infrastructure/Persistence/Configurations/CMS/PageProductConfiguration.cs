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
    public class PageProductConfiguration : IEntityTypeConfiguration<PageProduct>
    {
        public void Configure(EntityTypeBuilder<PageProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Page)
                .WithMany(x => x.PageProducts)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
