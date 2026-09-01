using AutoMapper;
using EasyReach_Application.CQRS.Querys.LandingPages;
using EasyReach_Application.DTOs.LandingPages.LandingPageProductItems;
using EasyReach_Application.Interfaces.Repositories.LandingPages;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.LandingPages;

public class GetPublishedLandingPagesQueryHandler(
    ILandingPageRepository repository,
    IMapper mapper,
    ICacheHelper cacheHelper) : IRequestHandler<GetPublishedLandingPagesQuery, PagedResult<LandingPageResponseDto>>
{
    public async Task<PagedResult<LandingPageResponseDto>> Handle(GetPublishedLandingPagesQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"landingpages:published:p{request.PaginationParams.PageNumber}_s{request.PaginationParams.PageSize}";

        var result = await cacheHelper.GetOrSetAsync(
            cacheKey,
            async () =>
            {
                var pagedPages = await repository.GetPagedAsync(
                    request.PaginationParams,
                    predicate: p => p.IsPublished,
                    orderBy: q => q.OrderByDescending(p => p.CreatedAt),
                    includeProperties: "Products"
                );

                var mappedItems = mapper.Map<List<LandingPageResponseDto>>(pagedPages.Items);

                return new PagedResult<LandingPageResponseDto>(
                    mappedItems,
                    pagedPages.TotalCount,
                    pagedPages.PageNumber,
                    pagedPages.PageSize
                );
            },
            TimeSpan.FromMinutes(15)
        );

        return result ?? new PagedResult<LandingPageResponseDto>([], 0, request.PaginationParams.PageNumber, request.PaginationParams.PageSize);
    }
}

