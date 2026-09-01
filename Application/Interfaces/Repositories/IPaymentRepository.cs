using EasyReach_Domain.Entities.Payments;

namespace EasyReach_Application.Interfaces.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        // ১. Transaction ID দিয়ে পেমেন্ট খোঁজার মেথড
        Task<Payment?> GetByTransactionIdAsync(string transactionId);

        // ২. নির্দিষ্ট ইউজারের সব পেমেন্ট হিস্ট্রি খোঁজার মেথড
        Task<List<Payment>> GetByUserIdAsync(Guid userId); // Guid UserId
    }
}
