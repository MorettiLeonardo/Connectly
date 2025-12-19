using System;
using System.Collections.Generic;
using System.Text;

namespace Connectly.Domain.DomainObjects.Data
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(T entity);
        void Remove(T entity);
    }
}