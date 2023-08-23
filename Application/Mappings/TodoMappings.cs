using Application.DTOs.Todos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class TodoMappings : Profile
    {
        public TodoMappings()
        {
            CreateMap<GetTodosDto, Todo>().ReverseMap();
            CreateMap<AddTodoDto, Todo>().ReverseMap(); 
            CreateMap<UpdateTodoDto, Todo>().ReverseMap();
        }
    }
}
