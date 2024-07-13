using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public class DeliveryDomainService : SouccarDomainService<Delivery, int>, IDeliveryDomainService
    {
        public DeliveryDomainService(IRepository<Delivery, int> deliveryRepository) : base(deliveryRepository)
        {
        }
    }
}

