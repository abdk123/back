using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Services
{
    public interface IInvoiceAppService : IAsyncSouccarAppService<InvoiceDto, int, FullPagedRequestDto, CreateInvoiceDto, UpdateInvoiceDto>
    {
        
    }
}

