using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Map
{
   public class DeliveryMapProfile : Profile
    {
        public DeliveryMapProfile()
        {
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
            CreateMap<Delivery, ReadDeliveryDto>();
            CreateMap<CreateDeliveryDto, Delivery>().ReverseMap();
            CreateMap<CreateDeliveryItemDto, DeliveryItem>().ReverseMap();
            CreateMap<UpdateDeliveryDto, Delivery>().ReverseMap();
            CreateMap<UpdateDeliveryItemDto, DeliveryItem>().ReverseMap();
            CreateMap<DeliveryItem, DeliveryItemDto>().ReverseMap();
        }
    }
}

