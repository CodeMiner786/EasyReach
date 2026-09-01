using FluentValidation;
using EasyReach_Application.DTOs.Catalogs;

namespace EasyReach_Application.Validators.Catalogs
{
    /// <summary>
    /// CreateBrandDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
            RuleFor(x => x.LogoUrl).MaximumLength(200).When(x => x.LogoUrl != null);
            RuleFor(x => x.Description).MaximumLength(2000).When(x => x.Description != null);
        }
    }
}
