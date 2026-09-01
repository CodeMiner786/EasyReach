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
    public class GetProductByIdQueryHandler(
        IGenericRepository<Product> productRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productDto = await cacheHelper.GetOrSetAsync(
                $"product:{request.Id}",
                async () =>
                {
                    var product = await productRepository.GetByIdAsync(request.Id);

                    // Null conditional operator (?. ) ব্যবহার করে Null Check সিম্পলিফাই করা হয়েছে
                    return product is null ? null : mapper.Map<ProductDto>(product);
                },
                TimeSpan.FromHours(2));

            return productDto is null ? throw new ProductNotFoundException(request.Id) : productDto;
        }
    }
}

