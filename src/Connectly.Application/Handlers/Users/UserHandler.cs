using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Users.Interfaces;
using Connectly.Application.Handlers.Users.Requests;
using Connectly.Application.Handlers.Users.Responses;
using Connectly.Domain.Entities;
using Connectly.Infra.Data.Repositories.UserRepositories;

namespace Connectly.Application.Handlers.Users
{
    public class UserHandler : IUserHandler
    {

        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
        {
            if (request == null)
            {
                return new ApiResponse<CreateUserResponse>(400, "Request is null", null!);
            }

            var user = new User(request.Name, request.UserName, request.Email, request.Password, request.Bio, request.AvatarUrl);

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.CommitAsync();

            var response = new CreateUserResponse
            {
                AvatarUrl = request.AvatarUrl,
                Bio = request.Bio,
                Email = request.Email,
                Name = request.Name,
                UserName = request.UserName
            };

            return new ApiResponse<CreateUserResponse>(200, "User created", response);
        }
    }
}
