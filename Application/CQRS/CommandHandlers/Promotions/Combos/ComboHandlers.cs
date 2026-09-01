using AutoMapper;
using EasyReach_Application.CQRS.Commands.Promotions.Combos;
using EasyReach_Application.CQRS.Querys.Promotions;
using EasyReach_Application.DTOs.Promotions;
using EasyReach_Application.Interfaces.Repositories.Promotions;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Promotions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Promotions.Combos
{
    public class ComboHandlers(
        IComboRepository comboRepo,
        IMapper mapper,
        ICacheHelper cacheHelper) :
        IRequestHandler<GetActiveCombosQuery, List<ComboDto>>,
        IRequestHandler<GetComboByIdQuery, ComboDto?>,
        IRequestHandler<CreateComboCommand, Guid>,
        IRequestHandler<UpdateComboCommand, bool>,
        IRequestHandler<DeleteComboCommand, bool>
    {
        private const string ListCacheKey = "promotions:combos:active";
        private static string GetSingleCacheKey(Guid id) => $"promotions:combos:{id}";

        // ১. Active Combos Query
        public async Task<List<ComboDto>> Handle(GetActiveCombosQuery request, CancellationToken cancellationToken)
        {
            var result = await cacheHelper.GetOrSetAsync(
                ListCacheKey,
                async () =>
                {
                    var combos = await comboRepo.GetActiveCombosWithItemsAsync();
                    return mapper.Map<List<ComboDto>>(combos);
                },
                TimeSpan.FromMinutes(15)
            );

            return result ?? [];
        }

        // ২. Single Combo By ID Query
        public async Task<ComboDto?> Handle(GetComboByIdQuery request, CancellationToken cancellationToken)
        {
            return await cacheHelper.GetOrSetAsync(
                GetSingleCacheKey(request.Id),
                async () =>
                {
                    var combo = await comboRepo.GetComboWithItemsAsync(request.Id);
                    return combo == null ? null : mapper.Map<ComboDto>(combo);
                },
                TimeSpan.FromMinutes(15)
            );
        }

        // ৩. Create Combo Command
        public async Task<Guid> Handle(CreateComboCommand request, CancellationToken cancellationToken)
        {
            var combo = mapper.Map<Combo>(request.ComboDto);
            combo.Id = Guid.NewGuid();
            combo.CreatedAt = DateTime.UtcNow;

            await comboRepo.AddAsync(combo);
            await comboRepo.SaveChangesAsync();

            await cacheHelper.RemoveAsync(ListCacheKey);
            return combo.Id;
        }

        // ৪. Update Combo Command
        public async Task<bool> Handle(UpdateComboCommand request, CancellationToken cancellationToken)
        {
            var combos = await comboRepo.FindAsync(c => c.Id == request.ComboDto.Id);
            var combo = combos.FirstOrDefault()
                ?? throw new KeyNotFoundException("Combo deal not found.");

            mapper.Map(request.ComboDto, combo);
            combo.UpdatedAt = DateTime.UtcNow;

            comboRepo.Update(combo);
            await comboRepo.SaveChangesAsync();

            // Clear cache for both list & single item
            await cacheHelper.RemoveAsync(ListCacheKey);
            await cacheHelper.RemoveAsync(GetSingleCacheKey(combo.Id));

            return true;
        }

        // ৫. Delete Combo Command
        public async Task<bool> Handle(DeleteComboCommand request, CancellationToken cancellationToken)
        {
            var combos = await comboRepo.FindAsync(c => c.Id == request.Id);
            var combo = combos.FirstOrDefault()
                ?? throw new KeyNotFoundException("Combo deal not found.");

            comboRepo.Remove(combo);
            await comboRepo.SaveChangesAsync();

            // Clear cache
            await cacheHelper.RemoveAsync(ListCacheKey);
            await cacheHelper.RemoveAsync(GetSingleCacheKey(request.Id));

            return true;
        }
    }
}
