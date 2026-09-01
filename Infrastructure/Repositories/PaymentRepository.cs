using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Payments;
using EasyReach_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EasyReach_Infrastructure.Repositories
{
    public class PaymentRepository(ApplicationDbContext context) : GenericRepository<Payment>(context), IPaymentRepository
    {
        public async Task<Payment?> GetByTransactionIdAsync(string transactionId)
        {
            return await _dbSet
                .Include(x => x.Order) // Order entity সহ লোড করবে
                .FirstOrDefaultAsync(x => x.TransactionId == transactionId);
        }

        public async Task<List<Payment>> GetByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Include(x => x.Order)
                .Where(x => x.Order.UserId == userId) // Payment -> Order -> UserId চেক করছে
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}


// IPaymentRepository er implementation. GenericRepository&lt;Payment&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Payment-specific custom method thakle shegulo likha hobe.

