using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Todos
{
    public class UpdateTodoDto : AddTodoDto
    {
        public int Id { get; set; }
    }
}
