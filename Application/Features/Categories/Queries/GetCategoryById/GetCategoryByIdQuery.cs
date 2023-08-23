using Application.DTOs.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GetAllCategoriesDto>
    {
        public int CategoryId { get; set; }
    }
}
