using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    /// <summary>
    /// ITestimonialRepository er implementation. GenericRepository&lt;Testimonial&gt;
    /// theke shob CRUD method already paay - ekhane shudhu constructor,
    /// ar bhobishyot e Testimonial-specific custom method thakle shegulo likha hobe.
    /// </summary>
    public class TestimonialRepository(ApplicationDbContext context) : GenericRepository<Testimonial>(context), ITestimonialRepository
    {
    }
}
