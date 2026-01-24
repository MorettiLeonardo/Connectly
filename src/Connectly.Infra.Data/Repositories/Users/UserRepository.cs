using Connectly.Domain.Entities;
using Connectly.Domain.Interfaces;
using Connectly.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Connectly.Infra.Data.Repositories.Users
{
    public class UserRepository
        : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
