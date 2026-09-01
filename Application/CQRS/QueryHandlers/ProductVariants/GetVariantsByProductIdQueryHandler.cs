using AutoMapper;
using EasyReach_Application.CQRS.Querys.ProductVariants;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Exceptions;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.ProductVariants
{
    public class GetVariantsByProductIdQueryHandler(
        IGenericRepository<Product> productRepository,
        IGenericRepository<ProductVariant> variantRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<GetVariantsByProductIdQuery, IEnumerable<ProductVariantDto>>
    {
        public async Task<IEnumerable<ProductVariantDto>> Handle(GetVariantsByProductIdQuery request, CancellationToken cancellationToken)
        {
            // 🛑 মূল প্রোডাক্ট বিদ্যমান কি না যাচাই
            var productExists = await productRepository.ExistsAsync(p => p.Id == request.ProductId);
            if (!productExists)
            {
                throw new ProductNotFoundException(request.ProductId);
            }

            var result = await cacheHelper.GetOrSetAsync(
                $"product:{request.ProductId}:variants",
                async () =>
                {
                    var variants = await variantRepository.FindAsync(v => v.ProductId == request.ProductId);
                    return mapper.Map<IEnumerable<ProductVariantDto>>(variants);
                },
                TimeSpan.FromHours(2));

            return result ?? [];
        }
    }
}

