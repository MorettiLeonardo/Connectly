using Connectly.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Connectly.Application.Handlers.Users
{
    public sealed class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secreteKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? string.Empty));
            var expirationTime = jwtSettings.GetValue<int>("ExpirationTimeInMinutes");

            //claims
            var claims = new List<Claim>()
            {
                new (JwtRegisteredClaimNames.Sub, user.Name),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            
            //montar token
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetValue<string>("Issuer"),
                audience: jwtSettings.GetValue<string>("Audience"),
                claims,
                expires: DateTime.UtcNow.AddMinutes(expirationTime),
                signingCredentials: new SigningCredentials(secreteKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
