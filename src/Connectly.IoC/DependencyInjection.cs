using Connectly.Application.Handlers.JwtService;
using Connectly.Application.Handlers.JwtService.Interfaces;
using Connectly.Application.Handlers.Posts;
using Connectly.Application.Handlers.Posts.Interfaces;
using Connectly.Application.Handlers.Users;
using Connectly.Application.Handlers.Users.Interfaces;
using Connectly.Domain.Contexts.Entities.Interfaces;
using Connectly.Infra.Data.Context;
using Connectly.Infra.Data.Repositories.Likes;
using Connectly.Infra.Data.Repositories.Posts;
using Connectly.Infra.Data.Repositories.Users;
using Connectly.IoC.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connectly.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //dbcontext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //identity
            services.RegisterIdentity(configuration);

            //handlers
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IPostHandler, PostHandler>();
            services.AddScoped<IJwtService, JwtService>();

            //repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();

            return services;
        }
    }
}
