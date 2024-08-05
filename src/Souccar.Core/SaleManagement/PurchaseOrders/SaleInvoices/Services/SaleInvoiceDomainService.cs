using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public class SaleInvoiceDomainService : SouccarDomainService<SaleInvoice, int>, ISaleInvoiceDomainService
    {
        private readonly IRepository<SaleInvoice, int> _saleInvoiceRepository;

        public SaleInvoiceDomainService(IRepository<SaleInvoice, int> saleInvoiceRepository) : base(saleInvoiceRepository)
        {
            _saleInvoiceRepository = saleInvoiceRepository;
        }
    }
}
