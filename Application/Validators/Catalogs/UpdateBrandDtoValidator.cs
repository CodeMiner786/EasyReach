using FluentValidation;
using EasyReach_Application.DTOs.Catalogs;

namespace EasyReach_Application.Validators.Catalogs
{
    /// <summary>
    /// UpdateBrandDto validate korar rule.
    /// </summary>
    public class UpdateBrandDtoValidator : AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
            RuleFor(x => x.LogoUrl).MaximumLength(200).When(x => x.LogoUrl != null);
            RuleFor(x => x.Description).MaximumLength(2000).When(x => x.Description != null);
        }
    }
}
