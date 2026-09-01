using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Identities
{
    public class AssignRolePermissionsDto
    {
        public Guid RoleId { get; set; }
        public List<Guid> PermissionIds { get; set; } = [];
    }
}
