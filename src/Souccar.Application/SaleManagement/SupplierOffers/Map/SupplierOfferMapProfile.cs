using AutoMapper;
using Souccar.SaleManagement.SupplierOffers.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.SupplierOffers.Map
{
    public class SupplierOfferMapProfile : Profile
    {
        public SupplierOfferMapProfile()
        {
            CreateMap<SupplierOffer, SupplierOfferDto>();
            CreateMap<CreateSupplierOfferDto, SupplierOffer>();
            CreateMap<SupplierOffer, CreateSupplierOfferDto>();
            CreateMap<UpdateSupplierOfferDto, SupplierOffer>();
            CreateMap<SupplierOffer, UpdateSupplierOfferDto>();
            CreateMap<SupplierOfferItem, UpdateSupplierOfferItemDto>();

            //SupplierOffer Item
            CreateMap<CreateSupplierOfferItemDto, SupplierOfferItem>();
            CreateMap<UpdateSupplierOfferItemDto, SupplierOfferItem>();
            CreateMap<SupplierOfferItem, SupplierOfferItemDto>();
            
        }
    }
}

