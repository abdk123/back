using Microsoft.EntityFrameworkCore;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public class RejectDeliveryAppService :
        AsyncSouccarAppService<DeliveryItem, RejectDeliveryItemDto, int, FullPagedRequestDto, RejectDeliveryItemDto, RejectDeliveryItemDto>, IRejectDeliveryAppService
    {
        private readonly IDeliveryItemDomainService _deliveryItemDomainService;
        public RejectDeliveryAppService(IDeliveryItemDomainService deliveryItemDomainService) : base(deliveryItemDomainService)
        {
            _deliveryItemDomainService = deliveryItemDomainService;
        }

        protected override IQueryable<DeliveryItem> CreateFilteredQuery(FullPagedRequestDto input)
        {
            var deliveries = _deliveryItemDomainService.GetAllRejected();
            if (!deliveries.Any())
                return null;
            return deliveries.
                SelectMany(x => x.DeliveryItems).Where(x => x.DeliveryItemStatus == DeliveryItemStatus.RejectAndRecordAsDamaged || x.DeliveryItemStatus == DeliveryItemStatus.RejectAndReturnToSupplier);
        }
    }
}
