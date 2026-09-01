using EasyReach_Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.Interfaces.JWT
{
    public interface IJwtTokenGenerator
    {
        (string Token, DateTime ExpiresAt) GenerateToken(ApplicationUser user);
    }
}
