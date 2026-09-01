using AutoMapper;
using EasyReach_Application.CQRS.Querys.Products;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Exceptions;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Products
{
    public class GetProductBySlugQueryHandler(
        IGenericRepository<Product> productRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<GetProductBySlugQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var productDto = await cacheHelper.GetOrSetAsync(
                $"product:slug:{request.Slug}",
                async () =>
                {
                    var productList = await productRepository.FindAsync(p => p.Slug == request.Slug);
                    var product = productList.FirstOrDefault();
                    return product is null ? null : mapper.Map<ProductDto>(product);
                },
                TimeSpan.FromHours(2));

            return productDto is null ? throw new ProductNotFoundException($"Product with slug '{request.Slug}' was not found.") : productDto;
        }
    }
}
