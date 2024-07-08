using AutoMapper;
using Souccar.SaleManagement.Settings.Stores.Dto;

namespace Souccar.SaleManagement.Settings.Stores.Map
{
   public class StoreMapProfile : Profile
    {
        public StoreMapProfile()
        {
            CreateMap<Store, StoreDto>();
            CreateMap<Store, ReadStoreDto>();
            CreateMap<CreateStoreDto, Store>();
            CreateMap<Store, CreateStoreDto>();
            CreateMap<UpdateStoreDto, Store>();
            CreateMap<Store, UpdateStoreDto>();
        }
    }
}

