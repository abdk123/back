using AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Map
{
   public class InvoiceMapProfile : Profile
    {
        public InvoiceMapProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<Invoice, ReadInvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<Invoice, CreateInvoiceDto>();
            CreateMap<UpdateInvoiceDto, Invoice>();
            CreateMap<Invoice, UpdateInvoiceDto>();
        }
    }
}

