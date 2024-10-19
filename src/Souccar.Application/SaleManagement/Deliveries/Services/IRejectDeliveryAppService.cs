using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Deliveries.Dto;

namespace Souccar.SaleManagement.Deliveries.Services
{
    public interface IRejectDeliveryAppService : IAsyncSouccarAppService<RejectDeliveryItemDto, int, FullPagedRequestDto, RejectDeliveryItemDto, RejectDeliveryItemDto>
    {
    }
}
