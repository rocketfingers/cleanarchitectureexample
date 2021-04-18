using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
