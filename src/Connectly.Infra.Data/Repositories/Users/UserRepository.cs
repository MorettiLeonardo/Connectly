using Connectly.Domain.Contexts.Entities.Interfaces;
using Connectly.Domain.Contexts.Entities.Users;
using Connectly.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Connectly.Infra.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetUserById(Guid userId)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
