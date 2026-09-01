using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Navigations;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class NavigationMenuItemRepository(ApplicationDbContext context) : GenericRepository<NavigationMenuItem>(context), INavigationMenuItemRepository
    {
    }
}


// INavigationMenuItemRepository er implementation. GenericRepository&lt;NavigationMenuItem&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e NavigationMenuItem-specific custom method thakle shegulo likha hobe.

