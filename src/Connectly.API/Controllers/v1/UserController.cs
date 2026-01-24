using Connectly.Application.Handlers.Users.Interfaces;
using Connectly.Application.Handlers.Users.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Connectly.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        public UserController(IUserHandler userHandler  )
        {
            _userHandler = userHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var response = await _userHandler.CreateUserAsync(request);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
    }
}
