using Application.DTOs.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQuery : IRequest<IReadOnlyList<GetTodosDto>>
    {
        public string? SearchText { get; set; }
    }
}
