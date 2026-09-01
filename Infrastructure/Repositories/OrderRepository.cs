using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext context) : GenericRepository<Order>(context), IOrderRepository
    {
        public async Task<Order?> GetOrderWithDetailsAsync(Guid orderId)
        {
            return await _dbSet
                .Include(x => x.ShippingAddress)
                .Include(x => x.Items)
                .Include(x => x.StatusHistory)
                .FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<List<Order>> GetUserOrdersWithDetailsAsync(Guid userId)
        {
            return await _dbSet
                .Include(x => x.Items)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> HasOrderInLast24HoursAsync(Guid userId, string phoneNumber)
        {
            var last24Hours = DateTime.UtcNow.AddHours(-24);

            return await _dbSet
                .Include(x => x.ShippingAddress)
                .AnyAsync(x => (x.UserId == userId || x.ShippingAddress.Phone == phoneNumber)
                               && x.CreatedAt >= last24Hours);
        }
    }
}


