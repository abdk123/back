using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Services
{
    public interface IInvoiceAppService : IAsyncSouccarAppService<InvoiceDto, int, FullPagedRequestDto, CreateInvoiceDto, UpdateInvoiceDto>
    {
        InvoiceDto GetWithDetail(int id);
        Task<InvoiceDto> SaveInvoiceDetail(InvoiceDto input);
        Task<InvoiceDto> GetByOfferId(int offerId);
        IList<InvoiceItemForDeliveryDto> GetForDelivery(int customerId);
    }
}

