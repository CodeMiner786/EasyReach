using FluentValidation;
using EasyReach_Application.DTOs.CMS;

namespace EasyReach_Application.Validators.CMS
{
    /// <summary>
    /// CreatePageDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreatePageDtoValidator : AbstractValidator<CreatePageDto>
    {
        public CreatePageDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(2000);
        }
    }
}
