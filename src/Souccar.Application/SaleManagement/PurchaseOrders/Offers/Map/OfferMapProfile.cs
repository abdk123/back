using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Map
{
   public class OfferMapProfile : Profile
    {
        public OfferMapProfile()
        {
            CreateMap<Offer, OfferDto>();
            CreateMap<Offer, ReadOfferDto>();
            CreateMap<CreateOfferDto, Offer>();
            CreateMap<Offer, CreateOfferDto>();
            CreateMap<UpdateOfferDto, Offer>();
            CreateMap<Offer, UpdateOfferDto>();

            //Offer Item
            CreateMap<CreateOfferItemDto, OfferItem>();
            //CreateMap<UpdateOfferItemDto, OfferItem>();
            //CreateMap<OfferItem, OfferItemDto>();
        }
    }
}

