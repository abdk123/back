using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Map
{
   public class DeliveryMapProfile : Profile
    {
        public DeliveryMapProfile()
        {
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<Delivery, ReadDeliveryDto>();
            CreateMap<CreateDeliveryDto, Delivery>();
            CreateMap<Delivery, CreateDeliveryDto>();
            CreateMap<UpdateDeliveryDto, Delivery>();
            CreateMap<Delivery, UpdateDeliveryDto>();
        }
    }
}

