using AutoMapper;
using EasyReach_Application.CQRS.Querys.LandingPages;
using EasyReach_Application.DTOs.LandingPages.LandingPageProductItems;
using EasyReach_Application.Interfaces.Repositories.LandingPages;
using EasyReach_Application.IRedis;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.LandingPages;

public class GetLandingPageBySlugQueryHandler(
    ILandingPageRepository repository,
    IMapper mapper,
    ICacheHelper cacheHelper) : IRequestHandler<GetLandingPageBySlugQuery, LandingPageResponseDto?>
{
    public async Task<LandingPageResponseDto?> Handle(GetLandingPageBySlugQuery request, CancellationToken cancellationToken)
    {
        return await cacheHelper.GetOrSetAsync(
            $"landingpages:slug:{request.Slug.ToLower()}",
            async () =>
            {
                var page = await repository.GetBySlugWithProductsAsync(request.Slug);
                return page == null ? null : mapper.Map<LandingPageResponseDto>(page);
            },
            TimeSpan.FromMinutes(15)
        );
    }
}

