using AutoMapper;
using EasyReach_Application.CQRS.Querys.Brands;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Common.Paginations;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Brands
{
    public class GetAllBrandsQueryHandler(
        IGenericRepository<Brand> brandRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<GetAllBrandsQuery, PagedResult<BrandDto>>
    {
        public async Task<PagedResult<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"brands:p{request.PaginationParams.PageNumber}_s{request.PaginationParams.PageSize}";

            var result = await cacheHelper.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    var pagedBrands = await brandRepository.GetPagedAsync(
                        request.PaginationParams,
                        orderBy: q => q.OrderBy(b => b.Name)
                    );

                    var mappedItems = mapper.Map<List<BrandDto>>(pagedBrands.Items);

                    return new PagedResult<BrandDto>(
                        mappedItems,
                        pagedBrands.TotalCount,
                        pagedBrands.PageNumber,
                        pagedBrands.PageSize);
                },
                TimeSpan.FromHours(6));

            return result ?? new PagedResult<BrandDto>([], 0, request.PaginationParams.PageNumber, request.PaginationParams.PageSize);
        }
    }
}

