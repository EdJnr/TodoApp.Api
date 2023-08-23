using Application.DTOs.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Queries.GetTodoById
{
    public class GetTodoByIdQuery : IRequest<GetTodosDto>
    {
        public int TodoId { get; set; }
    }
}
