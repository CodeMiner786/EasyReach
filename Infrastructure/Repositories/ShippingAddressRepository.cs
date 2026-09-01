using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class ShippingAddressRepository(ApplicationDbContext context) : GenericRepository<ShippingAddress>(context), IShippingAddressRepository
    {
    }
}



// IShippingAddressRepository er implementation. GenericRepository&lt;ShippingAddress&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e ShippingAddress-specific custom method thakle shegulo likha hobe.

