using Connectly.Domain.DomainObjects.Data;

namespace Connectly.Domain.Contexts.Entities.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post?> GetPostById(Guid postId);
    }
}
