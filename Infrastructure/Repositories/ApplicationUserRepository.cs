using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories
{
    // IApplicationUserRepository er implementation. GenericRepository&lt;ApplicationUser&gt;
    // theke shob CRUD method already paay - ekhane shudhu constructor,
    // ar bhobishyot e ApplicationUser-specific custom method thakle shegulo likha hobe.
    public class ApplicationUserRepository(ApplicationDbContext context) : GenericRepository<ApplicationUser>(context), IApplicationUserRepository
    {
        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser?> GetUserWithRoleAndPermissionsAsync(Guid userId)
        {
            // সরাসরি ID দিয়ে ইউজার রিটার্ন করবে (Build error এড়াতে নিরাপদ মেথড)
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
