using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Posts.Requests;
using Connectly.Application.Handlers.Posts.Responses;

namespace Connectly.Application.Handlers.Posts.Interfaces
{
    public interface IPostHandler
    {
        Task<ApiResponse<CreatePostResponse>> CreatePostAsync(CreatePostRequest request);
        Task<ApiResponse<object>> ToggleLikeAsync(ToggleLikeRequest request);
    }
}
