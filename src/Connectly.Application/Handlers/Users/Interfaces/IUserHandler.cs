using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Users.Requests;
using Connectly.Application.Handlers.Users.Responses;
using Connectly.Domain.Entities;

namespace Connectly.Application.Handlers.Users.Interfaces
{
    public interface IUserHandler
    {
        Task<ApiResponse<ReturnOneUserResponse>> CreateUserAsync(CreateUserRequest request);
        Task<ApiResponse<List<GetAllUsersResponse>>> GetAllUsersAsync();
        Task<ApiResponse<ReturnOneUserResponse>> UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task<ApiResponse<ReturnOneUserResponse>> GetUserByIdAsync(Guid id);
    }
}
