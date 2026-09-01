using AutoMapper;
using EasyReach_Application.CQRS.Commands.LandingPages;
using EasyReach_Application.Interfaces.Repositories.LandingPages;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.LandingPages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.LandingPages
{
    public class CreateLandingPageCommandHandler(
        ILandingPageRepository repository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<CreateLandingPageCommand, Guid>
    {
        public async Task<Guid> Handle(CreateLandingPageCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<LandingPage>(request.Dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();

            await cacheHelper.RemoveAsync("landingpages:published");
            return entity.Id;
        }
    }
}
