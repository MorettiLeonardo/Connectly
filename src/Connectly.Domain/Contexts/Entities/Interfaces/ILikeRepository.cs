using Connectly.Domain.DomainObjects.Data;

namespace Connectly.Domain.Contexts.Entities.Interfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        Task<Like?> GetByUserAndPostAsync(Guid userId, Guid postId);
    }
}
