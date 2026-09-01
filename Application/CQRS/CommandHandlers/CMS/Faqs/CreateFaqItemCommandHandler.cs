using AutoMapper;
using EasyReach_Application.CQRS.Commands.CMS.Faqs;
using EasyReach_Application.CQRS.Querys.CMS.Faqs;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.CMS.Faqs
{
    public class CreateFaqItemCommandHandler(IFaqItemRepository repository, IMapper mapper)
    : IRequestHandler<CreateFaqItemCommand, Guid>
    {
        public async Task<Guid> Handle(CreateFaqItemCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<FaqItem>(request.Dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
            return entity.Id;
        }
    }

    public class UpdateFaqItemCommandHandler(IFaqItemRepository repository, IMapper mapper)
        : IRequestHandler<UpdateFaqItemCommand, bool>
    {
        public async Task<bool> Handle(UpdateFaqItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Dto.Id)
                ?? throw new KeyNotFoundException("FAQ not found.");

            mapper.Map(request.Dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            repository.Update(entity);
            await repository.SaveChangesAsync();
            return true;
        }
    }

    public class DeleteFaqItemCommandHandler(IFaqItemRepository repository)
        : IRequestHandler<DeleteFaqItemCommand, bool>
    {
        public async Task<bool> Handle(DeleteFaqItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("FAQ not found.");

            repository.Remove(entity);
            await repository.SaveChangesAsync();
            return true;
        }
    }

    public class GetAllFaqItemsQueryHandler(IFaqItemRepository repository, IMapper mapper)
        : IRequestHandler<GetAllFaqItemsQuery, List<FaqItemDto>>
    {
        public async Task<List<FaqItemDto>> Handle(GetAllFaqItemsQuery request, CancellationToken cancellationToken)
        {
            var list = await repository.GetAllAsync();
            return mapper.Map<List<FaqItemDto>>(list);
        }
    }
}
