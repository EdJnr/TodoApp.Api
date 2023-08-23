using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTodoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
        {
            _unitOfWork.Todo.DeleteAsync(command.TodoId);

            var results = await _unitOfWork.SaveChanges();
            return results;
        }
    }
}
