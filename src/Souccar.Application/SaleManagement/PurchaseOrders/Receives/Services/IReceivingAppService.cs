using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Services
{
    public interface IReceivingAppService : IAsyncSouccarAppService<ReceivingDto, int, FullPagedRequestDto, CreateReceivingDto, UpdateReceivingDto>
    {
        IList<ReceivingDto> GetAllByInvoiceId(int invoiceId);
    }
}

