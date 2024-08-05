using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Map
{
    public class SaleInvoiceMapProfile : Profile
    {
        public SaleInvoiceMapProfile()
        {
            CreateMap<SaleInvoice, SaleInvoiceDto>();
            CreateMap<SaleInvoice, ReadSaleInvoiceDto>();
            CreateMap<CreateSaleInvoiceDto, SaleInvoice>();
            CreateMap<SaleInvoice, CreateSaleInvoiceDto>();
            CreateMap<UpdateSaleInvoiceDto, SaleInvoice>();
            CreateMap<SaleInvoice, UpdateSaleInvoiceDto>();
            CreateMap<SaleInvoiceItem, SaleInvoiceItemDto>().ReverseMap();
            CreateMap<CreateSaleInvoiceItemDto, SaleInvoiceItem>().ReverseMap();
            CreateMap<UpdateSaleInvoiceItemDto, SaleInvoiceItem>().ReverseMap();
        }
    }
}
