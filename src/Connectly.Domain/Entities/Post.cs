using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Entities
{
    public class Post : BaseEntity
    {
        public Guid UserId { get; private set; }
        public string Content { get; private set; } = string.Empty;

        private readonly List<Comment> _comments = [];
        private readonly List<Like> _likes = [];

        public IReadOnlyCollection<Comment> Comments => _comments;
        public IReadOnlyCollection<Like> Likes => _likes;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
