using AutoMapper;
using EasyReach_Application.CQRS.Commands.Brands;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Brands
{
    public class CreateBrandCommandHandler(
        IGenericRepository<Brand> brandRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<CreateBrandCommand, BrandDto>
    {
        public async Task<BrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandEntity = mapper.Map<Brand>(request.Dto);
            brandEntity.Id = Guid.NewGuid();
            brandEntity.CreatedAt = DateTime.UtcNow;

            await brandRepository.AddAsync(brandEntity);
            await brandRepository.SaveChangesAsync();

            await cacheHelper.RemoveAsync("brands:all");

            return mapper.Map<BrandDto>(brandEntity);
        }
    }
}
