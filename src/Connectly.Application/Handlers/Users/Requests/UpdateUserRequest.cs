namespace Connectly.Application.Handlers.Users.Requests
{
    public class UpdateUserRequest
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
    }
}
