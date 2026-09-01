using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Interfaces;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Helpers.Slugs
{
    public class SlugService(IGenericRepository<Category> categoryRepository)
    {
        private readonly IGenericRepository<Category> _categoryRepository = categoryRepository;


        public async Task<Category> CreateCategoryAsync(CreateCategoryDto dto) 
        {
            string baseSlug = SlugHelper.GenerateSlug(dto.Name);
            string uniqueSlug = baseSlug;
            int counter = 1;

            while(await _categoryRepository.ExistsAsync(c=> c.Slug == uniqueSlug)) 
            {
                uniqueSlug = $"{baseSlug}-{counter}";
                counter++;
            }

            // Entity object e data map kora

            var category = new Category
            {
                Name = dto.Name,
                Slug = uniqueSlug,
                ImageUrl = dto.ImageUrl,
                IconUrl = dto.IconUrl,
                DisplayOrder = dto.DisplayOrder,
                ParentCategoryId = dto.ParentCategoryId,
                IsActive =true,
            };

            // Database e save kora
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return category;

        }
    }
}
