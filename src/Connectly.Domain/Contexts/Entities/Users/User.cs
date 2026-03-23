
using Microsoft.AspNetCore.Identity;

namespace Connectly.Domain.Contexts.Entities.Users
{
    public class User : IdentityUser<Guid>
    {
        protected User() { }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            UserName = email;
        }

        public string Name { get; private set; } = string.Empty;
        public string? Bio { get; private set; } = string.Empty;
        public string? AvatarUrl { get; private set; } = string.Empty;

        private readonly List<Follow> _following = [];
        private readonly List<Follow> _followers = [];

        public IReadOnlyCollection<Follow> Following => _following;
        public IReadOnlyCollection<Follow> Followers => _followers;
    }
}
