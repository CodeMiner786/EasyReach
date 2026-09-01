using FluentValidation;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Identities
{
    /// <summary>
    /// UpdateApplicationUserDto validate korar rule. Password ekhane update
    /// hoy na - password change er jonno alada "Change Password" flow lagbe.
    /// </summary>
    public class UpdateApplicationUserDtoValidator : AbstractValidator<UpdateApplicationUserDto>
    {
        public UpdateApplicationUserDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.FullName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(200);
            RuleFor(x => x.PhoneNumber).MaximumLength(200).When(x => x.PhoneNumber != null);
            RuleFor(x => x.ProfileImageUrl).MaximumLength(200).When(x => x.ProfileImageUrl != null);
            RuleFor(x => x.UserType).IsInEnum();
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Shothik email format din.");
        }
    }
}
