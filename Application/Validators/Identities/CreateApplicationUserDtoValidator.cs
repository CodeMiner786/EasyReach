using FluentValidation;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Identities
{
    /// <summary>
    /// CreateApplicationUserDto validate korar rule - notun Customer/Manager
    /// register korar shomoy ei validator চলবে.
    /// </summary>
    public class CreateApplicationUserDtoValidator : AbstractValidator<CreateApplicationUserDto>
    {
        public CreateApplicationUserDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(200);
            RuleFor(x => x.PhoneNumber).MaximumLength(200).When(x => x.PhoneNumber != null);
            RuleFor(x => x.ProfileImageUrl).MaximumLength(200).When(x => x.ProfileImageUrl != null);
            RuleFor(x => x.UserType).IsInEnum();
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Shothik email format din.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
                .WithMessage("Password kom pokkhe 6 character hote hobe.");
        }
    }
}
