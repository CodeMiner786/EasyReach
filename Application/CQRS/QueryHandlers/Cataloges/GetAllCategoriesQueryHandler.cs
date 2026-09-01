using AutoMapper;
using EasyReach_Application.CQRS.Querys.Cataloges;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Cataloges
{
    public class GetAllCategoriesQueryHandler(
        IGenericRepository<Category> categoryRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await cacheHelper.GetOrSetAsync(
                "categories:all",
                async () =>
                {
                    var categories = await categoryRepository.GetAllAsync();
                    return mapper.Map<IEnumerable<CategoryDto>>(categories);
                },
                TimeSpan.FromHours(12));

            return result ?? [];
        }
    }
}

