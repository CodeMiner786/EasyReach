using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Navigations;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Infrastructure.Persistence.Configurations.Navigations
{
    // NavigationMenuItem entity er EF Core Fluent API configuration - table name,
    // column constraint (required/max length), decimal precision, unique
    // index, ar relationship/delete-behavior shob ekhane define kora.
    // ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    // diye eta automatic detect + apply hoy.

    public class NavigationMenuItemConfiguration : IEntityTypeConfiguration<NavigationMenuItem>
    {
        public void Configure(EntityTypeBuilder<NavigationMenuItem> builder)
        {
            builder.ToTable("NavigationMenuItems");
            builder.HasKey(x => x.Id);

            // Basic Column Constraints
            builder.Property(x => x.Label)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.IconClass)
                .HasMaxLength(100);

            builder.Property(x => x.Route)
                .HasMaxLength(500);

            // New Dynamic Linking Properties Configuration
            builder.Property(x => x.TargetType)
                .HasMaxLength(100);

            builder.Property(x => x.TargetId)
                .HasMaxLength(200);

            // Relationships Configuration

            // 1. Self-referencing (Parent-Child Menu)
            builder.HasOne(x => x.ParentMenuItem)
                .WithMany(p => p.ChildMenuItems)
                .HasForeignKey(x => x.ParentMenuItemId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. Required Permission (RBAC Link)
            builder.HasOne(x => x.RequiredPermission)
                .WithMany()
                .HasForeignKey(x => x.RequiredPermissionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. User Audit (CreatedBy User Link)
            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.CreatedByUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
