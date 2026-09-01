using EasyReach_Domain.Entities.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.Interfaces.Repositories.Promotions
{
    public interface IComboRepository : IGenericRepository<Combo>
    {
        Task<Combo?> GetComboWithItemsAsync(Guid comboId);
        Task<List<Combo>> GetActiveCombosWithItemsAsync();
    }
}
