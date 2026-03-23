using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Users;
using Connectly.Application.Handlers.Users.Interfaces;
using Connectly.Application.Handlers.Users.Requests;
using Connectly.Application.Handlers.Users.Responses;
using Connectly.Domain.DomainObjects.Data;
using Microsoft.AspNetCore.Mvc;

namespace Connectly.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        public UserController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<RegisterResponse>>> Register(
            [FromBody] RegisterRequest request)
        {
            var result = await _userHandler.RegisterAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> Login(
            [FromBody] LoginRequest request)
        {
            var result = await _userHandler.LoginAsync(request);

            if (!result.IsSuccess)
                return Unauthorized(result);

            return Ok(result);
        }
    }
}