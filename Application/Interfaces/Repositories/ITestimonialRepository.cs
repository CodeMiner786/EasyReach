using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Testimonial er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Testimonial&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Testimonial er jonno kono extra/custom query (e.g. GetActiveTestimonialsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface ITestimonialRepository : IGenericRepository<Testimonial>
    {
    }
}
