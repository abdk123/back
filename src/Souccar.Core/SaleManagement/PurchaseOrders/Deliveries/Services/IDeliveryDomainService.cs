using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public interface IDeliveryDomainService : ISouccarDomainService<Delivery, int>
    {
        IQueryable<Delivery> GetAllByInvoiceId(int invoiceId);
        IQueryable<Delivery> GetAllWithDetail();
        Task<Delivery> GetWithDetailsByIdAsync(int id);
        Task<IQueryable<Delivery>> GetAllDeliverdAsync();
    }
}

