using AutoMapper;
using EasyReach_Application.CQRS.Commands.Products;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Files;
using EasyReach_Application.Helpers.Slugs;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Products
{
    public class CreateProductCommandHandler(
        IGenericRepository<Product> productRepository,
        IFileStorageService fileStorageService,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<CreateProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // ১. প্রোডাক্ট নেম থেকে বেজ স্লগ তৈরি
            string baseSlug = SlugHelper.GenerateSlug(request.Dto.Name);
            string uniqueSlug = baseSlug;
            int counter = 1;

            while (await productRepository.ExistsAsync(p => p.Slug == uniqueSlug))
            {
                uniqueSlug = $"{baseSlug}-{counter}";
                counter++;
            }

            // ২. Entity mapping এবং Base/Slug অ্যাসাইন
            var productEntity = mapper.Map<Product>(request.Dto);
            productEntity.Id = Guid.NewGuid();
            productEntity.Slug = uniqueSlug;
            productEntity.CreatedAt = DateTime.UtcNow;
            productEntity.CreatedByUserId = request.CreatedByUserId;

            // 📷 ৩. ছবি আপলোড হ্যান্ডলিং
            if (request.ImageStream != null && !string.IsNullOrEmpty(request.ImageFileName))
            {
                var imageUrl = await fileStorageService.UploadAsync(
                    request.ImageStream,
                    request.ImageFileName,
                    request.ImageContentType ?? "image/jpeg",
                    "products",
                    cancellationToken
                );

                productEntity.Images.Add(new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ProductId = productEntity.Id,
                    ImageUrl = imageUrl,
                    IsPrimary = true,
                    DisplayOrder = 1,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // 📦 ৪. Nested Variants হ্যান্ডলিং (যদি রিকোয়েস্টে ভ্যারিয়েন্ট পাঠানো হয়)
            if (request.Dto.Variants != null && request.Dto.Variants.Count > 0)
            {
                foreach (var variantDto in request.Dto.Variants)
                {
                    var variantEntity = mapper.Map<ProductVariant>(variantDto);
                    variantEntity.Id = Guid.NewGuid();
                    variantEntity.ProductId = productEntity.Id; // অটো-লিঙ্ক করা হলো
                    variantEntity.CreatedAt = DateTime.UtcNow;

                    productEntity.Variants.Add(variantEntity);
                }
            }

            // ৫. ডাটাবেজে সেভ
            await productRepository.AddAsync(productEntity);
            await productRepository.SaveChangesAsync();

            // ৬. ক্যাশ ক্লিয়ার করা
            await cacheHelper.RemoveAsync("products:all");

            return mapper.Map<ProductDto>(productEntity);
        }
    }
}
