using Connectly.Application.Configurations;
using Connectly.Application.Handlers.JwtService.Interfaces;
using Connectly.Domain.Contexts.Entities.Users;
using Connectly.Domain.Contexts.Entities.Users.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Connectly.Application.Handlers.JwtService
{
    public class JwtService : IJwtService
    {

        #region Properties

        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        #endregion

        #region Constructor

        public JwtService(UserManager<User> userManager, IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
        }

        #endregion

        public async Task<string> GenerateTokenAsync(string email)
        {
            // Busca case-insensitive para evitar duplicata quando email vem em caixa diferente (ex: Google)
            var user = await _userRepository.GetUserByEmail((email ?? string.Empty).Trim().ToLowerInvariant());
            return await GenerateTokenAsync(user!);
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim("UserId", user.Id.ToString()),
        };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

    }
}
