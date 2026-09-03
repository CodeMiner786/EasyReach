using AutoMapper;
using EasyReach_Application.CQRS.Commands.Promotions;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.Interfaces.Repositories.Promotions;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Promotions;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Promotions
{
    public class DiscountHandlers(
        IDiscountRepository discountRepo,
        IMapper mapper,
        ICacheHelper cacheHelper) :
        IRequestHandler<CreateDiscountCommand, Guid>,
        IRequestHandler<UpdateDiscountCommand, bool>,
        IRequestHandler<DeleteDiscountCommand, bool>
    {
        private const string CacheKey = "promotions:discounts:active";

        // ১. Create Command
        public async Task<Guid> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = mapper.Map<Discount>(request.DiscountDto);
            discount.Id = Guid.NewGuid();
            discount.CreatedAt = DateTime.UtcNow;

            await discountRepo.AddAsync(discount);
            await discountRepo.SaveChangesAsync();

            // Cache Invalidation
            await cacheHelper.RemoveAsync(CacheKey);
            return discount.Id;
        }

        // ২. Update Command
        public async Task<bool> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discounts = await discountRepo.FindAsync(d => d.Id == request.DiscountDto.Id);
            var discount = discounts.FirstOrDefault()
                ?? throw new KeyNotFoundException("Discount not found.");

            mapper.Map(request.DiscountDto, discount);
            discount.UpdatedAt = DateTime.UtcNow;

            discountRepo.Update(discount);
            await discountRepo.SaveChangesAsync();

            // Cache Invalidation
            await cacheHelper.RemoveAsync(CacheKey);
            return true;
        }

        // ৩. Delete Command
        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var discounts = await discountRepo.FindAsync(d => d.Id == request.Id);
            var discount = discounts.FirstOrDefault()
                ?? throw new KeyNotFoundException("Discount not found.");

            discountRepo.Remove(discount);
            await discountRepo.SaveChangesAsync();

            // Cache Invalidation
            await cacheHelper.RemoveAsync(CacheKey);
            return true;
        }
    }
}

