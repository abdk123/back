using AutoMapper;
using Souccar.SaleManagement.Settings.Units.Dto;

namespace Souccar.SaleManagement.Settings.Units.Map
{
   public class SizeMapProfile : Profile
    {
        public SizeMapProfile()
        {
            CreateMap<Size, SizeDto>();
            CreateMap<Size, ReadSizeDto>();
            CreateMap<CreateSizeDto, Size>();
            CreateMap<Size, CreateSizeDto>();
            CreateMap<UpdateSizeDto, Size>();
            CreateMap<Size, UpdateSizeDto>();
            CreateMap<Size, SizeForDropdownDto>();
        }
    }
}

