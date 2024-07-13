using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public class InvoiceDomainService : SouccarDomainService<Invoice, int>, IInvoiceDomainService
    {
        public InvoiceDomainService(IRepository<Invoice, int> invoiceRepository) : base(invoiceRepository)
        {
        }
    }
}

