using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public interface IInvoiceDomainService : ISouccarDomainService<Invoice, int>
    {
        IQueryable<Invoice> GetAllWithDetail();
        Task<Invoice> GetByOfferIdAsync(int offerId);
        Invoice GetWithDetail(int id);
        IQueryable<Invoice> GetForDelivery(int customerId);
        IList<int> GetOffersIds(int[] invoiceItemsIds);
    }
}

