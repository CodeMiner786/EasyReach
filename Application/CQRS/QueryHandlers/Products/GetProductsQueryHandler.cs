using AutoMapper;
using EasyReach_Application.CQRS.Querys.Products;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Common.Paginations;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;
using System.Linq.Expressions;

namespace EasyReach_Application.CQRS.QueryHandlers.Products
{
    public class GetProductsQueryHandler(
        IGenericRepository<Product> productRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<GetProductsQuery, PagedResult<ProductDto>?>
    {
        public async Task<PagedResult<ProductDto>?> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"products:page:{request.Params.PageNumber}:size:{request.Params.PageSize}:search:{request.SearchTerm ?? "none"}";

            // GetOrSetAsync ব্যবহার করার কারণে ক্যাশে থাকলে সরাসরি ক্যাশ থেকে রিটার্ন করবে,
            // আর না থাকলে ফ্যাক্টরি মেথড চালিয়ে ডাটাবেজ থেকে এনে অটো ক্যাশে সেভ করবে।
            return await cacheHelper.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    // ১. সার্চ ফিল্টার সেট করা (যদি সার্চ টার্ম থাকে)
                    Expression<Func<Product, bool>>? predicate = null;
                    if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                    {
                        string term = request.SearchTerm.ToLower();
                        predicate = p => p.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase) || (p.Slug != null && p.Slug.Contains(term));
                    }

                    // ২. আপনার Generic Repository-র GetPagedAsync কল করা
                    var pagedEntities = await productRepository.GetPagedAsync(
                        paginationParams: request.Params,
                        predicate: predicate,
                        orderBy: q => q.OrderByDescending(p => p.CreatedAt)
                    );

                    // ৩. Entity থেকে DTO-তে ম্যাপিং
                    var productDtos = mapper.Map<List<ProductDto>>(pagedEntities.Items);

                    // ৪. PagedResult<ProductDto> অবজেক্ট তৈরি করে রিটার্ন
                    return new PagedResult<ProductDto>(
                        productDtos,
                        pagedEntities.TotalCount,
                        pagedEntities.PageNumber,
                        pagedEntities.PageSize
                    );
                },
                expiration: TimeSpan.FromMinutes(10)
            );
        }
    }
}

