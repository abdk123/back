using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Services
{
    public interface IReceivingAppService : IAsyncSouccarAppService<ReceivingDto, int, FullPagedRequestDto, ReceivingDto, ReceivingDto>
    {
        
    }
}

