﻿using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public interface ISaleInvoiceAppService : IAsyncSouccarAppService<SaleInvoiceDto, int, FullPagedRequestDto, CreateSaleInvoiceDto, UpdateSaleInvoiceDto>
    {
        Task<SaleInvoiceDto> GetWithDetailsByIdAsync(int saleInvoiceId);
        Task<PdfAndUrnDto> GetPdfAndUrnByIdAsync(int saleInvoiceId);
    }
}
