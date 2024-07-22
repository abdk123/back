using Souccar.Core.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public interface IInvoiceDomainService : ISouccarDomainService<Invoice, int>
    {
        IQueryable<Invoice> GetAllWithDetail();
        Task<Invoice> GetByOfferIdAsync(int offerId);
        Invoice GetWithDetail(int id);
    }
}

