using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Carts;
using EasyReach_Domain.Entities.Catalogs;
using EasyReach_Domain.Entities.CMSs;
using EasyReach_Domain.Entities.Dashboards;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Domain.Entities.LandingPages;
using EasyReach_Domain.Entities.Navigations;
using EasyReach_Domain.Entities.Notifications;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Entities.Payments;
using EasyReach_Domain.Entities.Promotions;
using EasyReach_Domain.Entities.Reviews;
using EasyReach_Domain.Entities.Wishlists;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace EasyReach_Infrastructure.Persistence
{
    // EF Core DbContext - shob entity ekhane DbSet hisebe register kora.
    // OnModelCreating e ApplyConfigurationsFromAssembly() rakha hoyeche jate
    // porborti te (configuration class banonor shomoy) IEntityTypeConfiguration
    // implement kora prottek class automatically detect + apply hoy - alada
    // kore Fluent API ekhane likhte hobe na.
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        // ---------- Identities ----------
        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<AdminActivityLog> AdminActivityLogs => Set<AdminActivityLog>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();

        // ---------- Catalogs ----------
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();

        // ---------- Promotions ----------
        public DbSet<Discount> Discounts => Set<Discount>();
        public DbSet<Combo> Combos => Set<Combo>();
        public DbSet<ComboItem> ComboItems => Set<ComboItem>();

        // ---------- Carts ----------
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        // ---------- Wishlists ----------
        public DbSet<Wishlist> Wishlists => Set<Wishlist>();
        public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();

        // ---------- Reviews ----------
        public DbSet<ProductReview> ProductReviews { get; set; }

        // ---------- Orders ----------
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<OrderStatusHistory> OrderStatusHistories => Set<OrderStatusHistory>();
        public DbSet<ShippingAddress> ShippingAddresses => Set<ShippingAddress>();

        // ---------- Payments ----------
        public DbSet<Payment> Payments => Set<Payment>();

        // ---------- CMS ----------
        public DbSet<Banner> Banners => Set<Banner>();
        public DbSet<Testimonial> Testimonials => Set<Testimonial>();
        public DbSet<FaqItem> FaqItems => Set<FaqItem>();
        public DbSet<Page> Pages => Set<Page>();

        // ---------- Notifications ----------
        public DbSet<Notification> Notifications => Set<Notification>();

        // ---------- Landing Page ----------
        public DbSet<LandingPage> LandingPages { get; set; }
        public DbSet<LandingPageProduct> LandingPageProducts { get; set; }

        // ---------- Dashboards ----------
        public DbSet<DashboardWidget> DashboardWidgets => Set<DashboardWidget>();
        public DbSet<DashboardWidgetAssignment> DashboardWidgetAssignments => Set<DashboardWidgetAssignment>();

        // ---------- Navigations ----------
        public DbSet<NavigationMenuItem> NavigationMenuItems => Set<NavigationMenuItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ei assembly te thaka shob IEntityTypeConfiguration<T> class
            // automatically apply hobe - configuration class alada file e likhle hobe
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // ---------- Global Soft Delete Filter ----------
            // Shob AuditableEntity (IsDeleted property thaka) entity er jonno
            // automatic query filter lagano hocche - IsDeleted = true thakle
            // shei row DB theke hard delete na hoye shob normal query
            // (GetAllAsync, FindAsync etc.) theke automatically bad pore jabe.
            // Kono history/log kokhono permanently delete hobe na, shudhu
            // "hidden" thakbe. Dorkar hole IgnoreQueryFilters() diye purono
            // deleted data o dekha jabe (audit/recovery er jonno).
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var isDeletedProperty = Expression.Property(parameter, nameof(AuditableEntity.IsDeleted));
                    var notDeletedExpression = Expression.Not(isDeletedProperty);
                    var lambda = Expression.Lambda(notDeletedExpression, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
        }
    }
}
