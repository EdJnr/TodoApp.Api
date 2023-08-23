using Application.DTOs.Categories;
using Application.Features.Categories.Queries.GetAllCategories;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetAllCategoriesDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllCategoriesDto> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var fromDb = await _unitOfWork.Category.GetAsync(query.CategoryId);

            var result = _mapper.Map<GetAllCategoriesDto>(fromDb);
            return result;
        }
    }
}
