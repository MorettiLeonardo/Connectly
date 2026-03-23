using Connectly.Domain.Contexts.Entities.Users;

namespace Connectly.Application.Handlers.JwtService.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(string email);
        Task<string> GenerateTokenAsync(User user);
    }
}
