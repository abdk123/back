using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IRejectDeliveryAppService : IAsyncSouccarAppService<RejectDeliveryItemDto, int, FullPagedRequestDto, RejectDeliveryItemDto, RejectDeliveryItemDto>
    {
    }
}
