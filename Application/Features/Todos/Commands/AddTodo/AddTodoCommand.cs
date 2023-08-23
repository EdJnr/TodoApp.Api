using Application.DTOs.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.AddTodo
{
    public class AddTodoCommand : IRequest<int>
    {
        public AddTodoDto dto { get; set; }
    }
}
