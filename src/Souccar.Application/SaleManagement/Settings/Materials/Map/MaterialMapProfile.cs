using AutoMapper;
using Souccar.Core.Dto;
using Souccar.SaleManagement.Settings.Materials.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Map
{
    public class MaterialMapProfile : Profile
    {
        public MaterialMapProfile()
        {
            CreateMap<Material, MaterialDto>();
            CreateMap<Material, ReadMaterialDto>();
            CreateMap<CreateMaterialDto, Material>();
            CreateMap<Material, CreateMaterialDto>();
            CreateMap<UpdateMaterialDto, Material>()
                .ForMember(x => x.Stocks, op => op.Ignore());
            CreateMap<Material, UpdateMaterialDto>();
            CreateMap<Material, DropdownDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}

