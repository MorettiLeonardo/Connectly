using Connectly.Domain.Entities;
using Connectly.Infra.Data.Context;
using Connectly.Infra.Data.Repositories.UserRepositories;

namespace Connectly.Infra.Data.Repositories.Users
{
    public class UserRepository
        : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
