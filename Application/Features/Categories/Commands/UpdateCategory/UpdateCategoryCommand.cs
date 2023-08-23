using Application.DTOs.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public UpdateCategoryDto dto { get; set; }
    }
}
