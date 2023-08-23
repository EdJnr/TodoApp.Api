using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.AddTodo
{
    public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddTodoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddTodoCommand command, CancellationToken cancellation)
        {
            //check if selected category exists
            var category = (_unitOfWork.Category.GetAsync(command.dto.CategoryId)).Result;
            if (category == null)
            {
                throw new InvalidOperationException("The selected category does not exist");
            }

            var model = _mapper.Map<Todo>(command.dto);

            await _unitOfWork.Todo.CreateAsync(model);
            var results = await _unitOfWork.SaveChanges();

            return results;
        }
    }
}
