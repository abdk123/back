using Souccar.Core.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IDeliveryItemDomainService : ISouccarDomainService<DeliveryItem, int>
    {
        IQueryable<Delivery> GetAllRejected();

    }
}

