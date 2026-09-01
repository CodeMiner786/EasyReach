using EasyReach_Domain.Entities.LandingPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Persistence.Configurations.LandingPages
{
    public class LandingPageProductConfiguration : IEntityTypeConfiguration<LandingPageProduct>
    {
        public void Configure(EntityTypeBuilder<LandingPageProduct> builder)
        {
            builder.HasKey(lp => lp.Id);

            builder.Property(lp => lp.CustomOfferPrice)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(lp => lp.LandingPage)
                   .WithMany(l => l.LandingPageProducts)
                   .HasForeignKey(lp => lp.LandingPageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(lp => lp.Product)
                   .WithMany()
                   .HasForeignKey(lp => lp.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
