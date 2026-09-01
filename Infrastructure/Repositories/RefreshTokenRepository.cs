using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories
{
    // IRefreshTokenRepository er implementation. GenericRepository<RefreshToken>
    // theke shob CRUD method already paay.
    public class RefreshTokenRepository(ApplicationDbContext context) : GenericRepository<RefreshToken>(context), IRefreshTokenRepository
    {
        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.Set<RefreshToken>()
                .FirstOrDefaultAsync(t => t.Token == token);
        }

        public async Task RevokeAllUserTokensAsync(Guid userId, string revokedByIp)
        {
            var activeTokens = await _context.Set<RefreshToken>()
                .Where(t => t.UserId == userId && !t.IsRevoked && t.ExpiresAt > DateTime.UtcNow)
                .ToListAsync();

            foreach (var token in activeTokens)
            {
                token.IsRevoked = true;
                token.RevokedAt = DateTime.UtcNow;
                token.RevokedByIp = revokedByIp;
            }

            _context.Set<RefreshToken>().UpdateRange(activeTokens);
        }
    }
}


// IRefreshTokenRepository er implementation. GenericRepository&lt;RefreshToken&gt;
// theke shob CRUD + soft-delete method already paay.


