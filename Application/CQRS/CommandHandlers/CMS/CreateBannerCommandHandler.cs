using AutoMapper;
using EasyReach_Application.CQRS.Commands.CMS;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.CMS
{
    public class CreateBannerCommandHandler(IBannerRepository repository, IMapper mapper)
    : IRequestHandler<CreateBannerCommand, Guid>
    {
        public async Task<Guid> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Banner>(request.Dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
            return entity.Id;
        }
    }

    public class UpdateBannerCommandHandler(IBannerRepository repository, IMapper mapper)
        : IRequestHandler<UpdateBannerCommand, bool>
    {
        public async Task<bool> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Dto.Id)
                ?? throw new KeyNotFoundException("Banner not found.");

            mapper.Map(request.Dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            repository.Update(entity);
            await repository.SaveChangesAsync();
            return true;
        }
    }

    public class DeleteBannerCommandHandler(IBannerRepository repository)
        : IRequestHandler<DeleteBannerCommand, bool>
    {
        public async Task<bool> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("Banner not found.");

            repository.Remove(entity);
            await repository.SaveChangesAsync();
            return true;
        }
    }
}
