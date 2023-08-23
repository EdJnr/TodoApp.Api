using Application.DTOs.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IReadOnlyList<GetAllCategoriesDto>>
    {
        public string? CategoryName { get; set; }
    }
}
