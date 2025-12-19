using Connectly.Domain.Contexts.Interfaces;
using Connectly.Domain.DomainObjects.Data;
using Connectly.Domain.Entities;
using Connectly.Infra.Data.Context;

namespace Connectly.Infra.Data.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
