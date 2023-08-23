using Application.DTOs.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.AddNewCategory
{
    public class AddCategoryCommand : IRequest<int>
    {
        public AddCategoryDto? dto { get; set; }
    }
}
