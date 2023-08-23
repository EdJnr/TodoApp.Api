using Application.DTOs.Todos;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, IReadOnlyList<GetTodosDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTodosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetTodosDto>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var fromDb = request.SearchText != null ? 
                await _unitOfWork.Todo.Query(e=> (e.Title ?? string.Empty).Trim().ToLower() == request.SearchText.Trim().ToLower(), null, e=> e.Category) 
            : 
                await _unitOfWork.Todo.GetAllAsync();

            var results = _mapper.Map<IReadOnlyList<GetTodosDto>>(fromDb);
            return results;
        }
    }
}
