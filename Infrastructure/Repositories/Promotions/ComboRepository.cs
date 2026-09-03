using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.Interfaces.Repositories.Promotions;
using EasyReach_Domain.Entities.Promotions;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Repositories.Promotions
{
    public class ComboRepository(ApplicationDbContext context)
        : GenericRepository<Combo>(context), IComboRepository
    {
        public async Task<Combo?> GetComboWithItemsAsync(Guid comboId)
        {
            return await _dbSet.AsNoTracking()
                .Include(c => c.Items)
                .ThenInclude(i => i.ProductVariant)
                .FirstOrDefaultAsync(c => c.Id == comboId);
        }

        public async Task<List<Combo>> GetActiveCombosWithItemsAsync()
        {
            return await _dbSet.AsNoTracking()
                .Include(c => c.Items)
                .ThenInclude(i => i.ProductVariant)
                .Where(c => c.IsActive)
                .ToListAsync();
        }
    }
}
