using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }

        public async Task<int> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Category>(command.dto);

            await _unitOfWork.Category.UpdateAsync(command.Id, model);

            var result = await _unitOfWork.SaveChanges();
            return result;
        }
    }
}
