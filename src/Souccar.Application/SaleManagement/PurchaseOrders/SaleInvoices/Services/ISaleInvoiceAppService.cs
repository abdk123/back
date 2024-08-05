using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public interface ISaleInvoiceAppService : IAsyncSouccarAppService<SaleInvoiceDto, int, FullPagedRequestDto, CreateSaleInvoiceDto, UpdateSaleInvoiceDto>
    {
    }
}
