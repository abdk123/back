using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public interface ISaleInvoiceDomainService : ISouccarDomainService<SaleInvoice, int>
    {
        Task<SaleInvoice> GetWithDetailsByIdAsync(int saleInvoiceId);
    }
}
