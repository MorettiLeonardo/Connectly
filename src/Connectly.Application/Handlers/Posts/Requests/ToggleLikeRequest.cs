namespace Connectly.Application.Handlers.Posts.Requests
{
    public class ToggleLikeRequest
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
