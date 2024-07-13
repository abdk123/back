using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IDeliveryAppService : IAsyncSouccarAppService<DeliveryDto, int, FullPagedRequestDto, CreateDeliveryDto, UpdateDeliveryDto>
    {
        
    }
}

