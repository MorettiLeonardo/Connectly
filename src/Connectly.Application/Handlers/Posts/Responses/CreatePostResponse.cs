namespace Connectly.Application.Handlers.Posts.Responses
{
    public class CreatePostResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
