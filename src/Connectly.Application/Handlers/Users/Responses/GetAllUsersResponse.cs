namespace Connectly.Application.Handlers.Users.Responses
{
    public class GetAllUsersResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string UserName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string? Bio { get; init; }
        public string? AvatarUrl { get; init; }
    }

}
