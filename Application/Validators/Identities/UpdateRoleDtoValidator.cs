using FluentValidation;
using EasyReach_Application.DTOs.Identities;

namespace EasyReach_Application.Validators.Identities
{
    /// <summary>
    /// UpdateRoleDto validate korar rule.
    /// </summary>
    public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).MaximumLength(2000).When(x => x.Description != null);
        }
    }
}
