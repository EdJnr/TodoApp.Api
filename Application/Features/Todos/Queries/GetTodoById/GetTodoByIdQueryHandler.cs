using Application.DTOs.Todos;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Queries.GetTodoById
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, GetTodosDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTodoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTodosDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken) 
        {
            var fromDb = await _unitOfWork.Todo.GetAsync(request.TodoId);

            var result = _mapper.Map<GetTodosDto>(fromDb);
            return result;
        }
    }
}
