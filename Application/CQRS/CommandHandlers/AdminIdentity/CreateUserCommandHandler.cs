using AutoMapper;
using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.Interfaces.Repositories.HashPasswords;
using EasyReach_Domain.Entities.Identities;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.AdminIdentity
{
    public class CreateUserCommandHandler(
        IApplicationUserRepository userRepository,
        IMapper mapper,
        IPasswordHasher passwordHasher)
        : IRequestHandler<CreateUserCommand, ApplicationUserDto>
    {
        public async Task<ApplicationUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<ApplicationUser>(request.Dto);

            // IPasswordHasher ব্যবহার করে হ্যাশ করা হচ্ছে
            user.PasswordHash = passwordHasher.HashPassword(request.Dto.Password);

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();

            return mapper.Map<ApplicationUserDto>(user);
        }
    }
}

