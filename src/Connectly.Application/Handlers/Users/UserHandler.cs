using Connectly.Application.Configurations;
using Connectly.Application.Handlers.JwtService.Interfaces;
using Connectly.Application.Handlers.Users.Interfaces;
using Connectly.Application.Handlers.Users.Requests;
using Connectly.Application.Handlers.Users.Requests.Validation;
using Connectly.Application.Handlers.Users.Responses;
using Connectly.Domain.Contexts.Entities.Interfaces;
using Connectly.Domain.Contexts.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace Connectly.Application.Handlers.Users
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository _useRepository;
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtServie;
        
        public UserHandler(
            IUserRepository useRepository,
            UserManager<User> userManager,
            IJwtService jwtServie)
        {
            _useRepository = useRepository;
            _userManager = userManager;
            _jwtServie = jwtServie;
        }

        public async Task<ApiResponse<RegisterResponse>> RegisterAsync(RegisterRequest request)
        {
            var validator = new RegisterRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new ApiResponse<RegisterResponse>(400, "Not Valid Data", null!);
            }

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null)
            {
                return new ApiResponse<RegisterResponse>(400, "Email already in use", null!);
            }

            var user = new User(request.Name, request.Email);

            var result = await _userManager.CreateAsync(user, request.Password);

            var response = new RegisterResponse
            {
                Name = user.Name,
                Email = user.Email!,
            };

            return new ApiResponse<RegisterResponse>(200, "User created", response);
        }

        public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var validator = new LoginRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new ApiResponse<LoginResponse>(400, "Not Valid Data", null!);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return new ApiResponse<LoginResponse>(400, "Invalid email or password", null!);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordValid)
            {
                return new ApiResponse<LoginResponse>(400, "Invalid email or password", null!);
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                return new ApiResponse<LoginResponse>(400, "User is locked", null!);
            }

            var token = await _jwtServie.GenerateTokenAsync(user);

            var response = new LoginResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email!,
                Token = token
            };

            return new ApiResponse<LoginResponse>(200, string.Empty, response);
        }
    }
}
