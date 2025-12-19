namespace Connectly.Application.Handlers.Users.Requests
{
    public class RegisterUserRequest
    {
        public string Name { get; private set; } = string.Empty;
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Bio { get; private set; } = string.Empty;
    }
}
