using EasyReach_Application.Interfaces.Repositories.Promotions;
using EasyReach_Domain.Entities.Promotions;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories.Promotions
{
    public class DiscountRepository(ApplicationDbContext context)
        : GenericRepository<Discount>(context), IDiscountRepository
    {
        public async Task<List<Discount>> GetActiveDiscountsAsync()
        {
            var now = DateTime.UtcNow;
            return await _dbSet.AsNoTracking()
                .Where(d => d.IsActive && d.StartDate <= now && d.EndDate >= now)
                .ToListAsync();
        }
    }
}
