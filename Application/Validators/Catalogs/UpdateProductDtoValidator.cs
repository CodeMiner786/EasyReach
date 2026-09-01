using FluentValidation;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Catalogs
{
    /// <summary>
    /// UpdateProductDto validate korar rule.
    /// </summary>
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ShortDescription).MaximumLength(2000).When(x => x.ShortDescription != null);
            RuleFor(x => x.Description).MaximumLength(2000).When(x => x.Description != null);
            RuleFor(x => x.SKU).NotEmpty().MaximumLength(200);
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
