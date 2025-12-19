using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid PostId { get; private set; }

        public string Content { get; private set; } = string.Empty;

        public User User { get; private set; } = null!;
        public Post Post { get; private set; } = null!;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
