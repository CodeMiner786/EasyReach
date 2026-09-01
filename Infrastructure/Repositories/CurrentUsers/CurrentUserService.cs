using EasyReach_Application.Interfaces.CurrentUsers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Repositories.CurrentUsers
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public Guid? UserId
        {
            get
            {
                var user = httpContextAccessor.HttpContext?.User;
                var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                             ?? user?.FindFirst("sub")?.Value;

                return Guid.TryParse(userIdStr, out var id) ? id : null;
            }
        }

        public string? Email => httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
        public string? UserType => httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
    }
}
