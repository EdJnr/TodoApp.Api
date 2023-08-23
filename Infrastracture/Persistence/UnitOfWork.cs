using Application.Interfaces;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastracture.Persistence.Contexts;
using Infrastracture.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IbaseRepository<Todo> Todo => new BaseRepository<Todo>(_context);

        public IbaseRepository<Category> Category => new BaseRepository<Category>(_context);

        public void Dispose()
        {
           GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
