using AutoMapper;
using Souccar.SaleManagement.Settings.Units.Dto;

namespace Souccar.SaleManagement.Settings.Units.Map
{
   public class UnitSizeMapProfile : Profile
    {
        public UnitSizeMapProfile()
        {
            CreateMap<UnitSize, UnitSizeDto>();
            CreateMap<UnitSize, ReadUnitSizeDto>();
            CreateMap<CreateUnitSizeDto, UnitSize>();
            CreateMap<UnitSize, CreateUnitSizeDto>();
            CreateMap<UpdateUnitSizeDto, UnitSize>();
            CreateMap<UnitSize, UpdateUnitSizeDto>();
        }
    }
}

