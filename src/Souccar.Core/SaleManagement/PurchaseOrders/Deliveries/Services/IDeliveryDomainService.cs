using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IDeliveryDomainService : ISouccarDomainService<Delivery, int>
    {
        Task<Delivery> GetWithDetailsByIdAsync(int id);
    }
}

