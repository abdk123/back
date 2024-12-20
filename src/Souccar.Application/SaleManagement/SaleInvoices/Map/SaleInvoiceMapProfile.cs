﻿using AutoMapper;
using Souccar.SaleManagement.SaleInvoices.Dto;

namespace Souccar.SaleManagement.SaleInvoices.Map
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
            CreateMap<SaleInvoice, PdfAndUrnDto>().ReverseMap();
        }
    }
}
