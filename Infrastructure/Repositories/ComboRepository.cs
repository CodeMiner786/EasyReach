using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Promotions;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{ 
    public class ComboRepository(ApplicationDbContext context) : GenericRepository<Combo>(context), IComboRepository
    {
    }
}


// IComboRepository er implementation. GenericRepository&lt;Combo&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Combo-specific custom method thakle shegulo likha hobe.

