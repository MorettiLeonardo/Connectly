using Connectly.Domain.Contexts.Entities;
using Connectly.Domain.Contexts.Entities.Interfaces;
using Connectly.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Connectly.Infra.Data.Repositories.Likes
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Like?> GetByUserAndPostAsync(Guid userId, Guid postId)
        {
            return await _context.Likes
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == postId);
        }
    }
}
