using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Entities
{
    public class Follow : BaseEntity
    {
        public Guid FollowerId { get; private set; }
        public Guid FollowingId { get; private set; }

        public User Follower { get; private set; } = null!;
        public User Following { get; private set; } = null!;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
