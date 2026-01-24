using Connectly.Domain.DomainObjects.Data;
using Connectly.Domain.Entities;

namespace Connectly.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(Guid id);
    }
}
