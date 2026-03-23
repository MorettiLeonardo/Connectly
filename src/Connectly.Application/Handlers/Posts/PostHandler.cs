using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Posts.Interfaces;
using Connectly.Application.Handlers.Posts.Requests;
using Connectly.Application.Handlers.Posts.Requests.Validation;
using Connectly.Application.Handlers.Posts.Responses;
using Connectly.Domain.Contexts.Entities;
using Connectly.Domain.Contexts.Entities.Interfaces;

namespace Connectly.Application.Handlers.Posts
{
    public class PostHandler : IPostHandler
    {
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IUserRepository _userRepository;

        public PostHandler(
            IPostRepository postRepository,
            ILikeRepository likeRepository,
            IUserRepository userRepository) 
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<CreatePostResponse>> CreatePostAsync(CreatePostRequest request)
        {
            var validator = new CreatePostRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new ApiResponse<CreatePostResponse>(400, "Invalid data", null!);
            }

            var userId = request.UserId;

            var post = new Post(userId, request.Content);

            _postRepository.Add(post);
            await _postRepository.UnitOfWork.CommitAsync();

            var response = new CreatePostResponse
            {
                Id = post.Id,
                Content = post.Content,
            };

            return new ApiResponse<CreatePostResponse>(200, string.Empty, response);
        }

        public async Task<ApiResponse<object>> ToggleLikeAsync(ToggleLikeRequest request)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            if(user is null)
            {
                return new ApiResponse<object>(404, "User not found", null!);
            }

            var post = await _postRepository.GetPostById(request.PostId);

            if (post is null)
            {
                return new ApiResponse<object>(404, "Post not found", null!);
            }

            var existingLike = await _likeRepository
                .GetByUserAndPostAsync(user.Id, post.Id);

            if (existingLike != null)
            {
                // UNLIKE
                _likeRepository.Remove(existingLike);
                await _likeRepository.UnitOfWork.CommitAsync();

                return new ApiResponse<object>(200, string.Empty, null!);
            }

            // LIKE
            var like = new Like(request.PostId, request.UserId);

            _likeRepository.Add(like);
            await _likeRepository.UnitOfWork.CommitAsync();

            return new ApiResponse<object>(200, string.Empty, null!);
        }
    }
}
