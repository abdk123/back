using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Deliveries.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Deliveries.Services
{
    public interface IDeliveryAppService : IAsyncSouccarAppService<DeliveryDto, int, FullPagedRequestDto, CreateDeliveryDto, UpdateDeliveryDto>
    {
        Task<DeliveryDto> GetWithDetailsByIdAsync(int deliveryId);
        Task<List<DeliveryDto>> GetAllDeliverdAsync();
        IList<DeliveryDto> GetAllByCustomerId(int customerId);
        Task<DeliveryItemDto> ChangeItemStatusAsync(ChangeItemStatusInputDto input);
        Task<DeliveryDto> RejectDeliveryAsync(RejectDeliveryDto input);
    }
}

