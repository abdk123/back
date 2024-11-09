using AutoMapper;
using Souccar.SaleManagement.PurchaseInvoices.Receives;
using Souccar.SaleManagement.Receives.Dto;

namespace Souccar.SaleManagement.Receives.Map
{
    public class ReceivingMapProfile : Profile
    {
        public ReceivingMapProfile()
        {
            CreateMap<Receiving, ReceivingDto>()
                .ForMember(x => x.CreatorUser, opt => opt.MapFrom((src, des, context) => src.CreatorUser?.FullName));
            CreateMap<ReceivingDto, Receiving>();
            CreateMap<ReceivingItem, ReceivingItemDto>().ReverseMap();
            CreateMap<Receiving, ReadReceivingDto>();
            CreateMap<CreateReceivingDto, Receiving>().ReverseMap();
            CreateMap<CreateReceivingItemDto, ReceivingItem>().ReverseMap();
            CreateMap<UpdateReceivingDto, Receiving>()
                .ForMember(x => x.ReceivingItems, opt => opt.Ignore());
            CreateMap<ReceivingItem, UpdateReceivingItemDto>();
            CreateMap<CompleteReceivingDto, Receiving>();
        }
    }
}

