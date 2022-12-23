using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ms.Common.Repositories.Contracts
{
   public interface IRepository<T> where T: IEntity
    {
        public Task CreateAsync(T entity);

        public Task<IReadOnlyCollection<T>> GetAllAsync();

        public Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);

        public Task<T> GetAsync(Guid id);

        public Task<T> GetAsync(Expression<Func<T, bool>> filter);

        public Task RemoveAsync(Guid id);

        public Task UpdateAsync(T entity);
        
    }
}
