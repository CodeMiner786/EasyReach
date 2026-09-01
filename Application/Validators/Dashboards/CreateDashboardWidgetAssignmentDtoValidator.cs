using FluentValidation;
using EasyReach_Application.DTOs.Dashboards;

namespace EasyReach_Application.Validators.Dashboards
{
    /// <summary>
    /// CreateDashboardWidgetAssignmentDto validate korar rule - Controller/Service e ei
    /// validator DI diye inject kore .ValidateAsync(dto) call korte hobe.
    /// </summary>
    public class CreateDashboardWidgetAssignmentDtoValidator : AbstractValidator<CreateDashboardWidgetAssignmentDto>
    {
        public CreateDashboardWidgetAssignmentDtoValidator()
        {
            RuleFor(x => x.DashboardWidgetId).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
