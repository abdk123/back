using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public interface ISaleInvoiceDomainService : ISouccarDomainService<SaleInvoice, int>
    {
        Task<IList<SaleInvoice>> CheckSaleInvoiceAsync();
        IList<SaleInvoice> GetByOfferItems(int[] offerItemsIds);
        Task<SaleInvoice> GetWithDetailsByIdAsync(int saleInvoiceId);
    }
}
