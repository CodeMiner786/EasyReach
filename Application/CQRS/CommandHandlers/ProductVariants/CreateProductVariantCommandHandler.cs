using AutoMapper;
using EasyReach_Application.CQRS.Commands.ProductVariants;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Exceptions;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.ProductVariants
{
    public class CreateProductVariantCommandHandler(
        IGenericRepository<Product> productRepository,
        IGenericRepository<ProductVariant> variantRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<CreateProductVariantCommand, ProductVariantDto>
    {
        public async Task<ProductVariantDto> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
        {
            if (!request.Dto.ProductId.HasValue || request.Dto.ProductId == Guid.Empty)
            {
                throw new Exception("ProductId is required for creating a standalone variant.");
            }

            // 🛑 .Value ব্যবহার করায় Guid? থেকে Guid কনভার্সন এরর সমাধান হলো
            var productId = request.Dto.ProductId.Value;
            var parentProductExists = await productRepository.ExistsAsync(p => p.Id == productId);

            if (!parentProductExists)
            {
                throw new ProductNotFoundException(productId);
            }

            var variantEntity = mapper.Map<ProductVariant>(request.Dto);
            variantEntity.Id = Guid.NewGuid();
            variantEntity.ProductId = productId;
            variantEntity.CreatedAt = DateTime.UtcNow;

            await variantRepository.AddAsync(variantEntity);
            await variantRepository.SaveChangesAsync();

            await cacheHelper.RemoveAsync($"product:{variantEntity.ProductId}");

            return mapper.Map<ProductVariantDto>(variantEntity);
        }
    }
}

