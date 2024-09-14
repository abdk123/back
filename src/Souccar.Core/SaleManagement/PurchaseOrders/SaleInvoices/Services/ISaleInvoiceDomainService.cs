using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public interface ISaleInvoiceDomainService : ISouccarDomainService<SaleInvoice, int>
    {
        Task<IList<SaleInvoice>> CheckSaleInvoiceAsync();
        Task<SaleInvoice> GetWithDetailsByIdAsync(int saleInvoiceId);
    }
}
