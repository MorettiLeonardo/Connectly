using Connectly.Domain.DomainObjects;
using Connectly.Domain.DomainObjects.Data;
using Connectly.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Connectly.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public IUnitOfWork UnitOfWork => (IUnitOfWork)_context;

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
