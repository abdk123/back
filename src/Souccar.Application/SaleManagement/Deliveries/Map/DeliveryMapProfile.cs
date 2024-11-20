using AutoMapper;
using Souccar.SaleManagement.Deliveries.Dto;

namespace Souccar.SaleManagement.Deliveries.Map
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
            CreateMap<DeliveryItem, RejectDeliveryItemDto>().ReverseMap();
            CreateMap<RejectedMaterialDto, RejectedMaterial>().ReverseMap();
        }
    }
}

