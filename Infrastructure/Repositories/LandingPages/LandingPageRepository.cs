using EasyReach_Application.Interfaces.Repositories.LandingPages;
using EasyReach_Domain.Entities.LandingPages;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories.LandingPages
{
    public class LandingPageRepository(ApplicationDbContext context) : GenericRepository<LandingPage>(context), ILandingPageRepository
    {
        private new readonly ApplicationDbContext _context = context;

        public async Task<List<LandingPage>> GetPublishedWithProductsAsync()
        {
            return await _context.LandingPages
                .Include(lp => lp.LandingPageProducts)
                    .ThenInclude(lpp => lpp.Product)
                .Where(lp => lp.IsPublished)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<LandingPage?> GetBySlugWithProductsAsync(string slug)
        {
            return await _context.LandingPages
                .Include(lp => lp.LandingPageProducts)
                    .ThenInclude(lpp => lpp.Product)
                .FirstOrDefaultAsync(lp => lp.Slug == slug && lp.IsPublished);
        }

        public async Task<LandingPage?> GetByIdWithProductsAsync(Guid id)
        {
            return await _context.LandingPages
                .Include(lp => lp.LandingPageProducts)
                    .ThenInclude(lpp => lpp.Product)
                .FirstOrDefaultAsync(lp => lp.Id == id);
        }
    }
}

