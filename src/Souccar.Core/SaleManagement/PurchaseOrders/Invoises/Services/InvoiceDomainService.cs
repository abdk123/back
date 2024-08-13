using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public class InvoiceDomainService : SouccarDomainService<Invoice, int>, IInvoiceDomainService
    {
        private readonly IRepository<Invoice,int> _invoiceRepository;
        public InvoiceDomainService(IRepository<Invoice, int> invoiceRepository) : base(invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public IQueryable<Invoice> GetAllWithDetail()
        {
            return _invoiceRepository.GetAll()
                .Include(s => s.Offer).ThenInclude(s => s.Supplier)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems);
        }

        public IQueryable<Invoice> GetForDelivery(int customerId)
        {
            InvoiceStatus[] statusList = { InvoiceStatus.PartialRecieved, InvoiceStatus.Received, InvoiceStatus.PartialDelivered};
            return _invoiceRepository.GetAll()
                .Include(s => s.Offer).ThenInclude(s => s.Supplier)
                .Include(s => s.Offer).ThenInclude(s => s.Customer)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems)
                .Where(x => x.Offer.CustomerId == customerId && statusList.Contains(x.Status));
        }

        public async Task<Invoice> GetByOfferIdAsync(int offerId)
        {
            var invoice = await _invoiceRepository.FirstOrDefaultAsync(x=>x.OfferId == offerId);
            if (invoice == null)
                return null;
            await _invoiceRepository.EnsurePropertyLoadedAsync(invoice, x => x.InvoiseDetails);
            return invoice;
        }

        public Invoice GetWithDetail(int id)
        {
            return _invoiceRepository.GetAll()
                .Include(s => s.Offer).ThenInclude(s => s.Supplier)
                .Include(s => s.Offer).ThenInclude(s => s.Customer)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x=>x.Stocks)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems)
                .FirstOrDefault(x => x.Id == id);
        }

        public IList<int> GetOffersIds(int[] invoiceItemsIds)
        {
            var offersIds = _invoiceRepository.GetAllIncluding(x => x.InvoiseDetails)
                .Where(x => x.InvoiseDetails.Any(y => invoiceItemsIds.Contains(y.Id)))
                .Select(x => x.OfferId.Value);
            if (offersIds.Any())
            {
                return offersIds.ToList();
            }

            return new List<int>();
        }
    }
}

