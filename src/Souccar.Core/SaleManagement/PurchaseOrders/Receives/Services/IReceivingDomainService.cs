using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.PurchaseOrders.Receives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Receivings.Services
{
    public interface IReceivingDomainService : ISouccarDomainService<Receiving, int>
    {
        IQueryable<Receiving> GetAllByInvoiceId(int invoiceId);
        IList<ReceivingItem> GetItemsByReceivingId(int receivingId);
        Task DeleteItemAsync(int itemId);
    }
}

