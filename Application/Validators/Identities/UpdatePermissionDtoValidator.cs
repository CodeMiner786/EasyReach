using FluentValidation;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Identities
{
    /// <summary>
    /// UpdatePermissionDto validate korar rule.
    /// </summary>
    public class UpdatePermissionDtoValidator : AbstractValidator<UpdatePermissionDto>
    {
        public UpdatePermissionDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Module).IsInEnum();
            RuleFor(x => x.Description).MaximumLength(2000).When(x => x.Description != null);
        }
    }
}
