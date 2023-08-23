using Application.DTOs.Categories;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IReadOnlyList<GetAllCategoriesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetAllCategoriesDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var results = request.CategoryName == null ? 
                await _unitOfWork.Category.GetAllAsync() 
            : 
                await _unitOfWork.Category.Query(e => ((e.Name ?? String.Empty).Trim().ToLower()) == request.CategoryName.Trim().ToLower(), null, null);

            return _mapper.Map<IReadOnlyList<GetAllCategoriesDto>>(results);
        }
      
    }
}
