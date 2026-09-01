using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.Interfaces.CurrentUsers
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        string? Email { get; }
        string? UserType { get; }
    }
}
