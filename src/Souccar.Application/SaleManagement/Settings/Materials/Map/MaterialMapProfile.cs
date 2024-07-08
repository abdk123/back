using AutoMapper;
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
            CreateMap<UpdateMaterialDto, Material>();
            CreateMap<Material, UpdateMaterialDto>();
        }
    }
}

