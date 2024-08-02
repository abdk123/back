using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.PurchaseOrders.Receives;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IDeliveryDomainService : ISouccarDomainService<Delivery, int>
    {
        IQueryable<Delivery> GetAllByInvoiceId(int invoiceId);
        Task<Delivery> GetWithDetailsByIdAsync(int id);
    }
}

