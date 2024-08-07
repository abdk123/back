using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Map
{
    public class InvoiceMapProfile : Profile
    {
        public InvoiceMapProfile()
        {
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.Currency, op => op.MapFrom((src, des) =>
                {
                    if (src.Offer != null)
                    {
                        return (int)src.Offer.Currency;
                    }
                    return 0;
                }))

                .ForMember(x => x.PoNumber, op => op.MapFrom(src=>src.Offer.PorchaseOrderId))
                .ForMember(x => x.OfferDate, op => op.MapFrom(src=>src.Offer.CreationTime))
                .ForMember(x => x.ApproveDate, op => op.MapFrom(src=>src.Offer.ApproveDate))
                .ForMember(x => x.SupplierName, op => op.MapFrom((src, des) =>
                {
                    if (src.Offer?.Supplier != null)
                    {
                        return src.Offer.Supplier.FullName;
                    }
                    return "";
                }))
                .ForMember(x => x.CustomerName, op => op.MapFrom((src, des) =>
                {
                    if (src.Offer?.Customer != null)
                    {
                        return src.Offer.Customer.FullName;
                    }
                    return "";
                }))
                .ForMember(x => x.CustomerId, op => op.MapFrom((src, des) =>
                {
                    return src.Offer?.CustomerId;
                }));
            CreateMap<Invoice, ReadInvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<Invoice, CreateInvoiceDto>();
            CreateMap<UpdateInvoiceDto, Invoice>();
            CreateMap<Invoice, UpdateInvoiceDto>();

            //Invoice Item
            CreateMap<InvoiceItem, InvoiceItemDto>();
        }
    }
}

