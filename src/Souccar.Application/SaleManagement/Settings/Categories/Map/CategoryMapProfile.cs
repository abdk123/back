using AutoMapper;
using Souccar.SaleManagement.Settings.Categories.Dto;

namespace Souccar.SaleManagement.Settings.Categories.Map
{
   public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, ReadCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<Category, CategoryForDropdownDto>();
        }
    }
}

