using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Posts.Interfaces;
using Connectly.Application.Handlers.Posts.Requests;
using Connectly.Application.Handlers.Posts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectly.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/post")]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostHandler _postHandler;

        public PostController(IPostHandler postHandler)
        {
            _postHandler = postHandler;
        }

        public async Task<ActionResult<ApiResponse<CreatePostResponse>>> CreatePost(
            [FromBody] CreatePostRequest request)
        {
            var result = await _postHandler.CreatePostAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);  
        }

        [HttpPost]
        [Route("like")]
        public async Task<ActionResult<ApiResponse<CreatePostResponse>>> ToggleLike(
            [FromBody] ToggleLikeRequest request)
        {
            var result = await _postHandler.ToggleLikeAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
