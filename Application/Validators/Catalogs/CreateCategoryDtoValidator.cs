using FluentValidation;
using EasyReach_Application.DTOs.Catalogs;

namespace EasyReach_Application.Validators.Catalogs
{
    /// <summary>
    /// CreateCategoryDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ImageUrl).MaximumLength(200).When(x => x.ImageUrl != null);
            RuleFor(x => x.IconUrl).MaximumLength(200).When(x => x.IconUrl != null);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
