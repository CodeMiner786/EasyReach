using AutoMapper;
using EasyReach_Application.CQRS.Commands.CMS.Testimonials;
using EasyReach_Application.CQRS.Querys.CMS.Testimonials;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.CMS.Testimonials
{
    public class CreateTestimonialCommandHandler(ITestimonialRepository repository, IMapper mapper)
    : IRequestHandler<CreateTestimonialCommand, Guid>
    {
        public async Task<Guid> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Testimonial>(request.Dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
            return entity.Id;
        }
    }

    public class GetAllTestimonialsQueryHandler(ITestimonialRepository repository, IMapper mapper)
        : IRequestHandler<GetAllTestimonialsQuery, List<TestimonialDto>>
    {
        public async Task<List<TestimonialDto>> Handle(GetAllTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var list = await repository.GetAllAsync();
            return mapper.Map<List<TestimonialDto>>(list);
        }
    }
}
