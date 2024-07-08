using AutoMapper;
using Souccar.SaleManagement.Offers.Dto;
using Souccar.SaleManagement.Offers;

namespace Souccar.SaleManagement.Offers.Map
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
        }
    }
}

