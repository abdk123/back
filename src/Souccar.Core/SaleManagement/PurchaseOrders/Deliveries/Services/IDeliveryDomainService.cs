using Souccar.Core.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IDeliveryDomainService : ISouccarDomainService<Delivery, int>
    {
        IQueryable<Delivery> GetAllByCustomerId(int customerId);
        IQueryable<Delivery> GetAllWithDetail();
        Task<Delivery> GetWithDetailsByIdAsync(int id);
        Task<IQueryable<Delivery>> GetAllDeliverdAsync();
        Task<DeliveryItem> ChangeItemStatusAsync(int id, int status);
        IQueryable<Delivery> GetAllRejected();
        IQueryable<Delivery> GetForSaleInvoice(int customerId);
        IQueryable<Delivery> GetByOfferItems(int[] offerItems);
    }
}

