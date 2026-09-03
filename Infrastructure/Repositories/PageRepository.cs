using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories
{
    public class PageRepository(ApplicationDbContext context) : GenericRepository<Page>(context), IPageRepository
    {
        private new readonly ApplicationDbContext _context = context;

        public async Task<Page?> GetPageWithDetailsBySlugAsync(string slug)
        {
            return await _context.Pages
                .Include(p => p.PageBanners)
                    .ThenInclude(pb => pb.Banner)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Variants)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Images)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Category)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Brand)
                .FirstOrDefaultAsync(p => p.Slug == slug && p.IsPublished);
        }

        public async Task<List<Page>> GetAllWithDetailsAsync()
        {
            return await _context.Pages
                .Include(p => p.PageBanners)
                    .ThenInclude(pb => pb.Banner)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Variants)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Images)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Category)
                .Include(p => p.PageProducts)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(prod => prod.Brand)
                .ToListAsync();
        }
    }
}
