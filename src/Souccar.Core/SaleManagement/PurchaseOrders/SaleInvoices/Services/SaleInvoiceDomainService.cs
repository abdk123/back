using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public class SaleInvoiceDomainService : SouccarDomainService<SaleInvoice, int>, ISaleInvoiceDomainService
    {
        private readonly IRepository<SaleInvoice, int> _saleInvoiceRepository;

        public SaleInvoiceDomainService(IRepository<SaleInvoice, int> saleInvoiceRepository) : base(saleInvoiceRepository)
        {
            _saleInvoiceRepository = saleInvoiceRepository;
        }

        public async Task<SaleInvoice> GetWithDetailsByIdAsync(int saleInvoiceId)
        {
            return await _saleInvoiceRepository.GetAllIncluding(s => s.Customer)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem).ThenInclude(d => d.InvoiceItem)
                .ThenInclude(m=>m.OfferItem).ThenInclude(f=>f.Material)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem).ThenInclude(d => d.InvoiceItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Unit)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem).ThenInclude(d => d.InvoiceItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Size)
                .FirstOrDefaultAsync(x => x.Id == saleInvoiceId);
        }
    }
}
