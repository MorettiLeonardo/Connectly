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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var response = await _userHandler.CreateUserAsync(request);

            if (response == null)
                return BadRequest();

            return Created();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userHandler.GetAllUsersAsync();

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody]UpdateUserRequest request)
        {
            var response = await _userHandler.UpdateUserAsync(id, request);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var response = await _userHandler.GetUserByIdAsync(id);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
    }
}
