using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories
{
    // IPasswordResetTokenRepository er implementation. GenericRepository<PasswordResetToken>
    // theke shob CRUD method already paay. "Forgot Password" flow er jonno
    // valid token find korar custom query ekhane implement kora hoyeche.

    public class PasswordResetTokenRepository(ApplicationDbContext context) : GenericRepository<PasswordResetToken>(context), IPasswordResetTokenRepository
    {
        public async Task<PasswordResetToken?> GetValidTokenAsync(string token)
        {
            return await _context.Set<PasswordResetToken>()
                .FirstOrDefaultAsync(t => t.Token == token && !t.IsUsed && t.ExpiresAt > DateTime.UtcNow);
        }
    }
}


// IPasswordResetTokenRepository er implementation. GenericRepository&lt;PasswordResetToken&gt;
// theke shob CRUD + soft-delete method already paay.



