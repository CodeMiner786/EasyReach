using AutoMapper;
using EasyReach_Application.CQRS.Querys.CMS;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.CMS
{
    public class GetAllBannersQueryHandler(IBannerRepository repository, IMapper mapper)
        : IRequestHandler<GetAllBannersQuery, PagedResult<BannerDto>>
    {
        public async Task<PagedResult<BannerDto>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken)
        {
            var pagedBanners = await repository.GetPagedAsync(
                request.PaginationParams,
                orderBy: q => q.OrderByDescending(b => b.CreatedAt)
            );

            var mappedItems = mapper.Map<List<BannerDto>>(pagedBanners.Items);

            return new PagedResult<BannerDto>(
                mappedItems,
                pagedBanners.TotalCount,
                pagedBanners.PageNumber,
                pagedBanners.PageSize
            );
        }
    }

    public class GetBannerByIdQueryHandler(IBannerRepository repository, IMapper mapper)
        : IRequestHandler<GetBannerByIdQuery, BannerDto?>
    {
        public async Task<BannerDto?> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            return entity == null ? null : mapper.Map<BannerDto>(entity);
        }
    }
}

