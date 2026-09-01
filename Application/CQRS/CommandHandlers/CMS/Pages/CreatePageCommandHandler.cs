using AutoMapper;
using EasyReach_Application.CQRS.Commands.CMS.Pages;
using EasyReach_Application.CQRS.Querys.CMS.Pages;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.CMS.Pages
{
    public class CreatePageCommandHandler(IPageRepository repository, IMapper mapper)
    : IRequestHandler<CreatePageCommand, Guid>
    {
        public async Task<Guid> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Page>(request.Dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
            return entity.Id;
        }
    }

    public class UpdatePageCommandHandler(IPageRepository repository, IMapper mapper)
        : IRequestHandler<UpdatePageCommand, bool>
    {
        public async Task<bool> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Dto.Id)
                ?? throw new KeyNotFoundException("Page not found.");

            mapper.Map(request.Dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            repository.Update(entity);
            await repository.SaveChangesAsync();
            return true;
        }
    }

    public class GetAllPagesQueryHandler(IPageRepository repository, IMapper mapper)
        : IRequestHandler<GetAllPagesQuery, List<PageDto>>
    {
        public async Task<List<PageDto>> Handle(GetAllPagesQuery request, CancellationToken cancellationToken)
        {
            var list = await repository.GetAllAsync();
            return mapper.Map<List<PageDto>>(list);
        }
    }
}
