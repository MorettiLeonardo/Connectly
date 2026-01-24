using Connectly.Domain.DomainObjects.Data;
using Connectly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connectly.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Follow> Follows => Set<Follow>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Post> Posts => Set<Post>();

        public async Task<bool> CommitAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly
            );
        }
    }
}
