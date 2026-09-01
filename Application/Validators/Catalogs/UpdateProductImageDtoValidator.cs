using FluentValidation;
using EasyReach_Application.DTOs.Catalogs;

namespace EasyReach_Application.Validators.Catalogs
{
    /// <summary>
    /// UpdateProductImageDto validate korar rule.
    /// </summary>
    public class UpdateProductImageDtoValidator : AbstractValidator<UpdateProductImageDto>
    {
        public UpdateProductImageDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(200);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
