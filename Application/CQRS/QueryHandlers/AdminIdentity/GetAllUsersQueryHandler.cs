using AutoMapper;
using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.AdminIdentity
{
    public class GetAllUsersQueryHandler(IApplicationUserRepository userRepository, IMapper mapper)
        : IRequestHandler<GetAllUsersQuery, List<ApplicationUserDto>>
    {
        public async Task<List<ApplicationUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            return mapper.Map<List<ApplicationUserDto>>(users);
        }
    }

    public class GetUserByIdQueryHandler(IApplicationUserRepository userRepository, IMapper mapper)
        : IRequestHandler<GetUserByIdQuery, ApplicationUserDto?>
    {
        public async Task<ApplicationUserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id);
            return user == null ? null : mapper.Map<ApplicationUserDto>(user);
        }
    }
}
