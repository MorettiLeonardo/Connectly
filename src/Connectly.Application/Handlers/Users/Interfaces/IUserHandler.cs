using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Users.Requests;
using Connectly.Application.Handlers.Users.Responses;

namespace Connectly.Application.Handlers.Users.Interfaces
{
    public interface IUserHandler
    {
        Task<ApiResponse<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);
    }
}
