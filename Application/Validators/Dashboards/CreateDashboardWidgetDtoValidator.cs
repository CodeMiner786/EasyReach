using FluentValidation;
using EasyReach_Application.DTOs.Dashboards;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Dashboards
{
    /// <summary>
    /// CreateDashboardWidgetDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateDashboardWidgetDtoValidator : AbstractValidator<CreateDashboardWidgetDto>
    {
        public CreateDashboardWidgetDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.WidgetType).IsInEnum();
            RuleFor(x => x.DataSourceKey).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IconClass).MaximumLength(200).When(x => x.IconClass != null);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
