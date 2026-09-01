using FluentValidation;
using EasyReach_Application.DTOs.Dashboards;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.Validators.Dashboards
{
    /// <summary>
    /// UpdateDashboardWidgetDto validate korar rule.
    /// </summary>
    public class UpdateDashboardWidgetDtoValidator : AbstractValidator<UpdateDashboardWidgetDto>
    {
        public UpdateDashboardWidgetDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.WidgetType).IsInEnum();
            RuleFor(x => x.DataSourceKey).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IconClass).MaximumLength(200).When(x => x.IconClass != null);
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
