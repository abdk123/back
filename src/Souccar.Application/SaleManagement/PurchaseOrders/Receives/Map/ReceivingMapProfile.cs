using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Map
{
   public class ReceivingMapProfile : Profile
    {
        public ReceivingMapProfile()
        {
            CreateMap<Receiving, ReceivingDto>().ReverseMap();
            CreateMap<ReceivingItem, ReceivingItemDto>().ReverseMap();
            CreateMap<Receiving, ReadReceivingDto>();
            CreateMap<CreateReceivingDto, Receiving>().ReverseMap();
            CreateMap<CreateReceivingItemDto, ReceivingItem>().ReverseMap();
            CreateMap<UpdateReceivingDto, Receiving>().ReverseMap();
            CreateMap<UpdateReceivingItemDto, ReceivingItem>().ReverseMap();
        }
    }
}

