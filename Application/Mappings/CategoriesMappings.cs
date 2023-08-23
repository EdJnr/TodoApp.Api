using Application.DTOs.Categories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class CategoriesMappings : Profile
    {
        public CategoriesMappings() 
        {
            CreateMap<GetAllCategoriesDto, Category>().ReverseMap();

            CreateMap<AddCategoryDto, Category>().ReverseMap();

            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
