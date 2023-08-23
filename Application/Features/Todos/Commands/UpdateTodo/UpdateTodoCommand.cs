using Application.DTOs.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommand : IRequest<int>
    {
        public int TodoId { get; set; }

        public UpdateTodoDto dto { get; set; }
    }
}
