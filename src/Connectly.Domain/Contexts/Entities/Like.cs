using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Contexts.Entities
{
    public class Like : BaseEntity
    {
        protected Like() { }

        public Like(Guid postId, Guid userId)
        {
            PostId = postId;
            UserId = userId;
        }

        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }

        public Post Post { get; private set; } = null!;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
