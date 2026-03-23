namespace Connectly.Application.Handlers.Posts.Requests
{
    public class CreatePostRequest
    {
        public string Content { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
