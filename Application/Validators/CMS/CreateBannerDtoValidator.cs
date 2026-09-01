using FluentValidation;
using EasyReach_Application.DTOs.CMS;

namespace EasyReach_Application.Validators.CMS
{
    /// <summary>
    /// CreateBannerDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateBannerDtoValidator : AbstractValidator<CreateBannerDto>
    {
        public CreateBannerDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(200);
            RuleFor(x => x.RedirectUrl).MaximumLength(200).When(x => x.RedirectUrl != null);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate)
                .When(x => x.StartDate.HasValue && x.EndDate.HasValue)
                .WithMessage("EndDate obossoi StartDate er por hote hobe.");
        }
    }
}
