using AutoMapper;
using Souccar.SaleManagement.Invoises.Dto;
using Souccar.SaleManagement.PurchaseInvoices;

namespace Souccar.SaleManagement.Invoises.Map
{
    public class InvoiceMapProfile : Profile
    {
        public InvoiceMapProfile()
        {
            CreateMap<PurchaseInvoice, InvoiceDto>()
                .ForMember(x => x.Currency, op => op.MapFrom((src, des) =>
                {
                    if (src.Offer != null)
                    {
                        return (int)src.Offer.Currency;
                    }
                    return 0;
                }))

                .ForMember(x => x.PoNumber, op => op.MapFrom(src => src.Offer.PorchaseOrderId))
                .ForMember(x => x.OfferDate, op => op.MapFrom(src => src.Offer.CreationTime))
                .ForMember(x => x.ApproveDate, op => op.MapFrom(src => src.Offer.ApproveDate))
                .ForMember(x => x.SupplierName, op => op.MapFrom((src, des) =>
                {
                    if (src.Supplier != null)
                    {
                        return src.Supplier.FullName;
                    }
                    return "";
                }));
            CreateMap<PurchaseInvoice, ReadInvoiceDto>();
            CreateMap<CreateInvoiceDto, PurchaseInvoice>();
            CreateMap<PurchaseInvoice, CreateInvoiceDto>();
            CreateMap<UpdateInvoiceDto, PurchaseInvoice>();
            CreateMap<PurchaseInvoice, UpdateInvoiceDto>();

            //Invoice Item
            CreateMap<PurchaseInvoiceItem, InvoiceItemDto>();
        }
    }
}

