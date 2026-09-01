using FluentValidation;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Identities
{
    /// <summary>
    /// CreatePermissionDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreatePermissionDtoValidator : AbstractValidator<CreatePermissionDto>
    {
        public CreatePermissionDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Module).IsInEnum();
            RuleFor(x => x.Description).MaximumLength(2000).When(x => x.Description != null);
        }
    }
}
