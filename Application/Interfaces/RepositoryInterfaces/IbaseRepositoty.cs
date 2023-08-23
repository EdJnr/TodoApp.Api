using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IbaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<List<T>> Query(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes);

        Task<T> GetAsync(int id);

        Task CreateAsync(T item);

        Task UpdateAsync(int id,T item);

        void DeleteAsync(int id);

    }
}
