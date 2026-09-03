using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Application.Interfaces.Repositories.Promotions
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<List<Discount>> GetActiveDiscountsAsync();
    }
}

