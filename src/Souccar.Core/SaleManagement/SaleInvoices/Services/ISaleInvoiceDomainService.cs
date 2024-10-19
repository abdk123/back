using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.SaleInvoices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.SaleInvoices.Services
{
    public interface ISaleInvoiceDomainService : ISouccarDomainService<SaleInvoice, int>
    {
        Task<IList<SaleInvoice>> CheckSaleInvoiceAsync();
        IList<SaleInvoice> GetByOfferItems(int[] offerItemsIds);
        Task<SaleInvoice> GetWithDetailsByIdAsync(int saleInvoiceId);
    }
}
