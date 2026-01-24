namespace Connectly.Application.Handlers.Users.Responses
{
    public class ReturnOneUserResponse
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; } = string.Empty;
    }
}
