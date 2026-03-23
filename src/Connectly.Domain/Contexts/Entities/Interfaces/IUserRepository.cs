using Connectly.Domain.Contexts.Entities.Users;
using Connectly.Domain.DomainObjects.Data;

namespace Connectly.Domain.Contexts.Entities.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserById(Guid userId);
    }
}
