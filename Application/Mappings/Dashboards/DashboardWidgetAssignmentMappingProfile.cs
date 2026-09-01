using AutoMapper;
using EasyReach_Application.DTOs.Dashboards;
using EasyReach_Domain.Entities.Dashboards;

namespace EasyReach_Application.Mappings.Dashboards
{
    /// <summary>
    /// DashboardWidgetAssignment entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class DashboardWidgetAssignmentMappingProfile : Profile
    {
        public DashboardWidgetAssignmentMappingProfile()
        {
            CreateMap<DashboardWidgetAssignment, DashboardWidgetAssignmentDto>();
            CreateMap<CreateDashboardWidgetAssignmentDto, DashboardWidgetAssignment>();
            CreateMap<UpdateDashboardWidgetAssignmentDto, DashboardWidgetAssignment>();
        }
    }
}
