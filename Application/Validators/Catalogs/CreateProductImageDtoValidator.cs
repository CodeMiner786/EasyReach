using FluentValidation;
using EasyReach_Application.DTOs.Catalogs;

namespace EasyReach_Application.Validators.Catalogs
{
    /// <summary>
    /// CreateProductImageDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateProductImageDtoValidator : AbstractValidator<CreateProductImageDto>
    {
        public CreateProductImageDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(200);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
