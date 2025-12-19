using Connectly.Application.Configurations;
using Connectly.Application.Handlers.Users.Interfaces;
using Connectly.Application.Handlers.Users.Requests;
using Connectly.Domain.Contexts.Interfaces;
using Connectly.Domain.Entities;

namespace Connectly.Application.Handlers.Users
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<Guid>> RegisterUser(RegisterUserRequest request)
        {
            var user = new User(
                request.Name,
                request.UserName,
                request.Email,
                request.Password,
                request.Bio
            );

            _userRepository.Add(user);

            var success = await _userRepository.UnitOfWork.Commit();

            if (!success)
            {
                return new ApiResponse<Guid>(
                    500,
                    "Erro ao salvar o usuário",
                    Guid.Empty
                );
            }

            return new ApiResponse<Guid>(
                201,
                "Usuário registrado com sucesso",
                user.Id
            );
        }

    }
}
