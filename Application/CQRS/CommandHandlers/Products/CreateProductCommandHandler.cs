using AutoMapper;
using EasyReach_Application.CQRS.Commands.Products;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Helpers.Slugs; // 👈 SlugHelper Namespace
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
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<CreateProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // ১. প্রোডাক্ট নেম থেকে বেজ স্লগ তৈরি
            string baseSlug = SlugHelper.GenerateSlug(request.Dto.Name);
            string uniqueSlug = baseSlug;
            int counter = 1;

            // ২. ডুপ্লিকেট স্লগ প্রতিরোধ করতে চেক (যদি ডাটাবেজে একই স্লগ থাকে তবে -1, -2 যুক্ত করবে)
            while (await productRepository.ExistsAsync(p => p.Slug == uniqueSlug))
            {
                uniqueSlug = $"{baseSlug}-{counter}";
                counter++;
            }

            // ৩. Entity mapping এবং Slug অ্যাসাইন
            var productEntity = mapper.Map<Product>(request.Dto);
            productEntity.Id = Guid.NewGuid();
            productEntity.Slug = uniqueSlug; // 👈 Unique Slug যুক্ত হলো
            productEntity.CreatedAt = DateTime.UtcNow;

            await productRepository.AddAsync(productEntity);
            await productRepository.SaveChangesAsync();

            // ৪. ক্যাশ ক্লিয়ার করা
            await cacheHelper.RemoveAsync("products:all");

            return mapper.Map<ProductDto>(productEntity);
        }
    }
}


