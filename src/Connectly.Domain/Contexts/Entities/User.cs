using Connectly.Domain.DomainObjects;
using Connectly.Domain.ValueObjects;

namespace Connectly.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        
        public User(string name, string username, string email, string password, string? bio, string? avatarUrl)
        {
            Name = name;
            UserName = username;
            Email = email;
            Password = new Password(password);
            Bio = bio;
            AvatarUrl = avatarUrl;
        }

        public string Name { get; private set; } = string.Empty;
        public string UserName { get; private set; } = string.Empty;
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public string? Bio { get; private set; } = string.Empty;
        public string? AvatarUrl { get; private set; } = string.Empty;

        private readonly List<Follow> _following = [];
        private readonly List<Follow> _followers = [];

        public IReadOnlyCollection<Follow> Following => _following;
        public IReadOnlyCollection<Follow> Followers => _followers; 

        public void UpdateProfile(string? name, string? userName, string? bio)
        {
            Name = name!;
            UserName = userName!;
            Bio = bio;

            UpdatedAt = DateTime.UtcNow;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
