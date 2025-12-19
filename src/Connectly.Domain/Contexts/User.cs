using Connectly.Domain.DomainObjects;

namespace Connectly.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string username, string email, string password, string bio) 
        { 
            Name = name;
            UserName = username;
            Email = email;
            Password = password;
            Bio = bio;
        }

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

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string name, string username, string email, string password, string bio)
        {
            var user = new User(name, username, email, password, bio);

            return user;
        }

        public void UpdateName(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
        }

        public void UpdateUserName(string username)
        {
            if (username == null) throw new ArgumentNullException("username");

            UserName = username;
        }

        public void UpdateBio(string bio)
        {
            if (bio == null) throw new ArgumentNullException("bio");

            UserName = bio;
        }
    }
}
