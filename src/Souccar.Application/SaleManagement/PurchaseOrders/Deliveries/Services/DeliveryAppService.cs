using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public class DeliveryAppService :
        AsyncSouccarAppService<Delivery, DeliveryDto, int, FullPagedRequestDto, CreateDeliveryDto, UpdateDeliveryDto>, IDeliveryAppService
    {
        private readonly IDeliveryDomainService _deliveryDomainService;
        public DeliveryAppService(IDeliveryDomainService deliveryDomainService) : base(deliveryDomainService)
        {
            _deliveryDomainService = deliveryDomainService;
        }
    }
}

