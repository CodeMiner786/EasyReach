using FluentValidation;
using EasyReach_Application.DTOs.CMS;

namespace EasyReach_Application.Validators.CMS
{
    /// <summary>
    /// CreateFaqItemDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateFaqItemDtoValidator : AbstractValidator<CreateFaqItemDto>
    {
        public CreateFaqItemDtoValidator()
        {
            RuleFor(x => x.Question).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.Answer).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
