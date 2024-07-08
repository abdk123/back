using AutoMapper;
using Souccar.SaleManagement.Settings.Units.Dto;

namespace Souccar.SaleManagement.Settings.Units.Map
{
   public class UnitMapProfile : Profile
    {
        public UnitMapProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<Unit, ReadUnitDto>();
            CreateMap<CreateUnitDto, Unit>();
            CreateMap<Unit, CreateUnitDto>();
            CreateMap<UpdateUnitDto, Unit>();
            CreateMap<Unit, UpdateUnitDto>();
        }
    }
}

