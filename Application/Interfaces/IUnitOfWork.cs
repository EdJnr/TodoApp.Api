using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IbaseRepository<Category> Category { get; }

        IbaseRepository<Todo> Todo { get; }

        Task<int> SaveChanges();

        void Dispose();
    }
}
