using Connectly.Domain.DomainObjects.Data;

namespace Connectly.Domain.Contexts.Entities.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
    }
}
