using EasyReach_Application.Interfaces.JWT;
using EasyReach_Domain.Entities.Identities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Repositories.JWT
{
    public class JwtTokenGenerator(IConfiguration configuration) : IJwtTokenGenerator
    {
        public (string Token, DateTime ExpiresAt) GenerateToken(ApplicationUser user)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["Secret"] ?? "EasyReachSuperSecretKey1234567890!@#$";
            var issuer = jwtSettings["Issuer"] ?? "EasyReach";
            var audience = jwtSettings["Audience"] ?? "EasyReachUsers";

            var expiresAt = DateTime.UtcNow.AddHours(2);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(ClaimTypes.Name, user.FullName ?? string.Empty),
                new(ClaimTypes.Role, user.UserType.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
        }
    }
}
