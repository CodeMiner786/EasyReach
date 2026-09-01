using FluentValidation;
using EasyReach_Application.DTOs.Dashboards;

namespace EasyReach_Application.Validators.Dashboards
{
    /// <summary>
    /// UpdateDashboardWidgetAssignmentDto validate korar rule.
    /// </summary>
    public class UpdateDashboardWidgetAssignmentDtoValidator : AbstractValidator<UpdateDashboardWidgetAssignmentDto>
    {
        public UpdateDashboardWidgetAssignmentDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.DashboardWidgetId).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
