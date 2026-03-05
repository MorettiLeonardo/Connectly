using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Entities
{
    public class Like : BaseEntity
    {
        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }

        public Post Post { get; private set; } = null!;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
