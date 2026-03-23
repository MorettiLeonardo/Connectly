using Connectly.Domain.Contexts.Entities;
using Connectly.Domain.Contexts.Entities.Interfaces;
using Connectly.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Connectly.Infra.Data.Repositories.Posts
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Post?> GetPostById(Guid postId)
        {
            return await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == postId);
        }
    }
}
