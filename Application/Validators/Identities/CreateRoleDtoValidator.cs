using FluentValidation;
using EasyReach_Application.DTOs.Identities;

namespace EasyReach_Application.Validators.Identities
{
    /// <summary>
    /// CreateRoleDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).MaximumLength(2000).When(x => x.Description != null);
        }
    }
}
