using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseInvoices.Services
{
    public interface IInvoiceDomainService : ISouccarDomainService<PurchaseInvoice, int>
    {
        IQueryable<PurchaseInvoice> GetAllWithDetail();
        Task<PurchaseInvoice> GetByOfferIdAsync(int offerId);
        PurchaseInvoice GetWithDetail(int id);
        IQueryable<PurchaseInvoice> GetForDelivery(int customerId);
        IList<int> GetOffersIds(int[] invoiceItemsIds);
        IQueryable<PurchaseInvoice> GetAllByOfferId(int offerId);
    }
}

