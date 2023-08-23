using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTodoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
        {
            //check if selected category exists
            var category = (_unitOfWork.Category.GetAsync(command.dto.CategoryId)).Result;
            if (category == null)
            {
                throw new InvalidOperationException("The selected category does not exist");
            }

            var model = _mapper.Map<Todo>(command.dto);

            await _unitOfWork.Todo.UpdateAsync(command.TodoId, model);

            var result = await _unitOfWork.SaveChanges();
            return result;
        }
    }
}
