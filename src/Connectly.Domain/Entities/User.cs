using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Bio { get; private set; } = string.Empty;
        public string AvatarUrl { get; private set; } = string.Empty;

        private readonly List<Follow> _following = [];
        private readonly List<Follow> _followers = [];

        public IReadOnlyCollection<Follow> Following => _following;
        public IReadOnlyCollection<Follow> Followers => _followers;

        public User() { }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
