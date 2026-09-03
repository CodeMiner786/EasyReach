using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Application.Interfaces.Repositories.Promotions
{
    public interface IComboRepository : IGenericRepository<Combo>
    {
        Task<Combo?> GetComboWithItemsAsync(Guid comboId);
        Task<List<Combo>> GetActiveCombosWithItemsAsync();
    }
}
