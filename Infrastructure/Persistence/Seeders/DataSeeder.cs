using EasyReach_Application.Interfaces.Repositories.HashPasswords;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Persistence.Seeders
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            // ১. অটোমেটিক মাইগ্রেশন অ্যাপ্লাই (ডাটাবেজ ক্রিয়েট না থাকলে তৈরি হবে)
            if (context.Database.IsSqlServer())
            {
                await context.Database.MigrateAsync();
            }

            // ২. Dynamically ModuleType Enum থেকে প্রজেক্টের সব Module নাম নিবে
            var moduleTypes = Enum.GetValues<ModuleType>();

            // ৩. Default Permissions সিড করা
            if (!await context.Permissions.AnyAsync())
            {
                var permissions = new List<Permission>();

                foreach (var module in moduleTypes)
                {
                    permissions.Add(new Permission
                    {
                        Name = $"{module}.FullAccess",
                        Module = module,
                        Description = $"Full Access for {module} Module",
                        CanView = true,
                        CanCreate = true,
                        CanEdit = true,
                        CanDelete = true
                    });
                }

                await context.Permissions.AddRangeAsync(permissions);
                await context.SaveChangesAsync();
            }

            // ৪. SuperAdmin Role সিড করা
            var superAdminRole = await context.Roles
                .FirstOrDefaultAsync(r => r.Name == "SuperAdmin");

            if (superAdminRole == null)
            {
                superAdminRole = new Role
                {
                    Name = "SuperAdmin",
                    Description = "Full Control over the System",
                    IsSystemRole = true
                };
                await context.Roles.AddAsync(superAdminRole);
                await context.SaveChangesAsync();

                // সব পারমিশন SuperAdmin রোলের সাথে কানেক্ট করা
                var allPermissions = await context.Permissions.ToListAsync();
                foreach (var perm in allPermissions)
                {
                    await context.RolePermissions.AddAsync(new RolePermission
                    {
                        RoleId = superAdminRole.Id,
                        PermissionId = perm.Id
                    });
                }
                await context.SaveChangesAsync();
            }

            // ৫. Default SuperAdmin User সিড করা
            if (!await context.Users.AnyAsync(u => u.Email == "admin@easyreach.com"))
            {
                var adminUser = new ApplicationUser
                {
                    FullName = "Super Admin",
                    Email = "admin@easyreach.com",
                    PasswordHash = passwordHasher.HashPassword("Admin@123456"),
                    UserType = UserType.SuperAdmin,
                    RoleId = superAdminRole.Id,
                    IsActive = true
                };

                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}

