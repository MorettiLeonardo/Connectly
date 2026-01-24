using Azure.Core;
using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Users.Interfaces;
using Connectly.Application.Handlers.Users.Requests;
using Connectly.Application.Handlers.Users.Responses;
using Connectly.Domain.Entities;
using Connectly.Domain.Interfaces;

namespace Connectly.Application.Handlers.Users
{
    public class UserHandler : IUserHandler
    {

        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<ReturnOneUserResponse>> CreateUserAsync(CreateUserRequest request)
        {
            if (request == null)
                return new ApiResponse<ReturnOneUserResponse>(400, "Request is null", null!);

            var user = new User(request.Name, request.UserName, request.Email, request.Password, request.Bio, request.AvatarUrl);

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.CommitAsync();

            var response = new ReturnOneUserResponse
            {
                AvatarUrl = request.AvatarUrl,
                Bio = request.Bio,
                Email = request.Email,
                Name = request.Name,
                UserName = request.UserName
            };

            return new ApiResponse<ReturnOneUserResponse>(200, "User created", response);
        }

        public async Task<ApiResponse<List<GetAllUsersResponse>>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsers();

            if (users == null)
                return new ApiResponse<List<GetAllUsersResponse>>(404, "Users not found", null!);

            var response = users.Select(user => new GetAllUsersResponse
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Bio = user.Bio,
                AvatarUrl = user.AvatarUrl
            }).ToList();

            return new ApiResponse<List<GetAllUsersResponse>>(200, string.Empty, response); ;
        }

        public async Task<ApiResponse<ReturnOneUserResponse>> UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return new ApiResponse<ReturnOneUserResponse>(404, "Users not found", null!);

            user.UpdateProfile(request.Name, request.UserName, request.Bio);

            await _userRepository.UnitOfWork.CommitAsync();

            var response = new ReturnOneUserResponse
            {
                AvatarUrl = user.AvatarUrl,
                Bio = user.Bio,
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName
            };

            return new ApiResponse<ReturnOneUserResponse>(200, string.Empty, response); ;
        }

        public async Task<ApiResponse<ReturnOneUserResponse>> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return new ApiResponse<ReturnOneUserResponse>(404, "Users not found", null!);

            var response = new ReturnOneUserResponse
            {
                AvatarUrl = user.AvatarUrl,
                Bio = user.Bio,
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName
            };

            return new ApiResponse<ReturnOneUserResponse>(200, string.Empty, response); ;
        }
    }
}
