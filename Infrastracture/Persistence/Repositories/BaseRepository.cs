using Application.Interfaces.RepositoryInterfaces;
using Infrastracture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastracture.Persistence.Repositories
{
    public class BaseRepository<T> : IbaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context) => _context = context;

        public async Task CreateAsync(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
        }

       

        public async void DeleteAsync(int id)
        {
            //find item
            var item = await _context.Set<T>().FindAsync(id);

            if (item != null)
            {
                _context.Entry(item).State = EntityState.Detached;

                _context.Set<T>().Remove(item);
            }            
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var results = await _context.Set<T>().AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<T> GetAsync(int id)
        {
            var results = await _context.Set<T>().FindAsync(id);
                
            return results;
        }

        public async Task<List<T>> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (filter !=  null)
            {
                query = query.Where(filter);
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            var results = await query.ToListAsync();
            return results;
        }

        public async Task UpdateAsync(int id, T item)
        {
            var found = await _context.Set<T>().FindAsync(id);

            if (found != null)
            {
                _context.Entry(found).State = EntityState.Detached;

                _context.Set<T>().Update(item);
            }
        }
    }
}
