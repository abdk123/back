using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IDeliveryAppService : IAsyncSouccarAppService<DeliveryDto, int, FullPagedRequestDto, CreateDeliveryDto, UpdateDeliveryDto>
    {
        Task<DeliveryDto> GetWithDetailsByIdAsync(int deliveryId);
        Task<List<DeliveryDto>> GetAllDeliverdAsync();
    }
}

