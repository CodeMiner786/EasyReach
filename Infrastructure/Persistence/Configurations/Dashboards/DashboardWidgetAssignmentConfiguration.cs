using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyReach_Domain.Entities.Dashboards;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Infrastructure.Persistence.Configurations.Dashboards
{
    /// <summary>
    /// DashboardWidgetAssignment entity er EF Core Fluent API configuration - table name,
    /// column constraint (required/max length), decimal precision, unique
    /// index, ar relationship/delete-behavior shob ekhane define kora.
    /// ApplicationDbContext.OnModelCreating() e ApplyConfigurationsFromAssembly()
    /// diye eta automatic detect + apply hoy.
    /// </summary>
    public class DashboardWidgetAssignmentConfiguration : IEntityTypeConfiguration<DashboardWidgetAssignment>
    {
        public void Configure(EntityTypeBuilder<DashboardWidgetAssignment> builder)
        {
            builder.ToTable("DashboardWidgetAssignments");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.DashboardWidgetId, x.RoleId }).IsUnique();

            builder.HasOne(x => x.DashboardWidget)
                .WithMany(p => p.Assignments)
                .HasForeignKey(x => x.DashboardWidgetId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
