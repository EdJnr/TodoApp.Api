using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommand : IRequest<int>
    {
        public int TodoId { get; set; }
    }
}
