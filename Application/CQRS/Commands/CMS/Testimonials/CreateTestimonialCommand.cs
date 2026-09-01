using EasyReach_Application.DTOs.CMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.CMS.Testimonials
{
    public record CreateTestimonialCommand(CreateTestimonialDto Dto) : IRequest<Guid>;
    public record UpdateTestimonialCommand(UpdateTestimonialDto Dto) : IRequest<bool>;
    public record DeleteTestimonialCommand(Guid Id) : IRequest<bool>;
}
