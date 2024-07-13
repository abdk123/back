using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Map
{
   public class ReceivingMapProfile : Profile
    {
        public ReceivingMapProfile()
        {
            CreateMap<Receiving, ReceivingDto>();
            CreateMap<Receiving, ReadReceivingDto>();
            CreateMap<CreateReceivingDto, Receiving>();
            CreateMap<Receiving, CreateReceivingDto>();
            CreateMap<UpdateReceivingDto, Receiving>();
            CreateMap<Receiving, UpdateReceivingDto>();
        }
    }
}

