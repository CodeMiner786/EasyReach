using AutoMapper;
using EasyReach_Application.CQRS.Querys.Promotions;
using EasyReach_Application.DTOs.Promotions;
using EasyReach_Application.Interfaces.Repositories.Promotions;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Promotions
{
    public class GetActiveDiscountsQueryHandler(
        IDiscountRepository discountRepo,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<GetActiveDiscountsQuery, PagedResult<DiscountDto>>
    {
        public async Task<PagedResult<DiscountDto>> Handle(GetActiveDiscountsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"promotions:discounts:active:p{request.PaginationParams.PageNumber}_s{request.PaginationParams.PageSize}";

            var result = await cacheHelper.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    // IDiscountRepository-তে GetPagedAsync ব্যবহার করা অথবা Predicate দিয়ে ফিল্টার করা
                    var pagedDiscounts = await discountRepo.GetPagedAsync(
                        request.PaginationParams,
                        predicate: d => d.IsActive && d.StartDate <= DateTime.UtcNow && d.EndDate >= DateTime.UtcNow,
                        orderBy: q => q.OrderByDescending(d => d.CreatedAt)
                    );

                    var mappedItems = mapper.Map<List<DiscountDto>>(pagedDiscounts.Items);

                    return new PagedResult<DiscountDto>(
                        mappedItems,
                        pagedDiscounts.TotalCount,
                        pagedDiscounts.PageNumber,
                        pagedDiscounts.PageSize);
                },
                TimeSpan.FromMinutes(10)
            );

            return result ?? new PagedResult<DiscountDto>([], 0, request.PaginationParams.PageNumber, request.PaginationParams.PageSize);
        }
    }
}


