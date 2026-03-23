using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Contexts.Entities
{
    public class Post : BaseEntity
    {
        protected Post() { }

        public Post(Guid userId, string content)
        {
            UserId = userId;
            Content = content;
        }

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
