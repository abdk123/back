using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.Extinsions;

namespace Souccar.SaleManagement.PurchaseInvoices.Services
{
    public class InvoiceDomainService : SouccarDomainService<PurchaseInvoice, int>, IInvoiceDomainService
    {
        private readonly IRepository<PurchaseInvoice, int> _invoiceRepository;
        public InvoiceDomainService(IRepository<PurchaseInvoice, int> invoiceRepository) : base(invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public IQueryable<PurchaseInvoice> GetAllWithDetail()
        {
            return _invoiceRepository.GetAllIncluding(
                x => x.Supplier,
                i => i.InvoiseDetails,
                o => o.Offer,
                u=> u.CreatorUser)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems).ThenInclude(x => x.Receiving).ThenInclude(x => x.ClearanceCompany)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems).ThenInclude(x => x.Receiving).ThenInclude(x => x.TransportCompany)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size);

        }
        public IQueryable<PurchaseInvoice> GetAllByOfferId(int offerId)
        {
            return _invoiceRepository.GetAllIncluding(
                x => x.Supplier,
                i => i.InvoiseDetails,
                o => o.Offer)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems).ThenInclude(x => x.Receiving).ThenInclude(x => x.ClearanceCompany)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems).ThenInclude(x => x.Receiving).ThenInclude(x => x.TransportCompany)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Where(x => x.OfferId == offerId);

        }
        public IQueryable<PurchaseInvoice> GetForDelivery(int customerId)
        {
            PurchaseInvoiceStatus[] statusList = { PurchaseInvoiceStatus.PartialRecieved, PurchaseInvoiceStatus.Received, PurchaseInvoiceStatus.PartialDelivered };
            return _invoiceRepository.GetAll()
                .Include(s => s.Offer).ThenInclude(s => s.Customer)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Supplier)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems)
                .Where(x => x.Offer.CustomerId == customerId && statusList.Contains(x.Status));
        }
        public async Task<PurchaseInvoice> GetByOfferIdAsync(int offerId)
        {
            var invoice = await _invoiceRepository.FirstOrDefaultAsync(x => x.OfferId == offerId);
            if (invoice == null)
                return null;
            await _invoiceRepository.EnsurePropertyLoadedAsync(invoice, x => x.InvoiseDetails);
            return invoice;
        }
        public PurchaseInvoice GetWithDetail(int id)
        {
            return _invoiceRepository.GetAllIncluding(
                x => x.Supplier,
                i => i.InvoiseDetails,
                o => o.Offer)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems).ThenInclude(x => x.Receiving).ThenInclude(x => x.ClearanceCompany)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.ReceivingItems).ThenInclude(x => x.Receiving).ThenInclude(x => x.TransportCompany)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.InvoiseDetails).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
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

        public IList<PurchaseInvoice> GetWithIncludeMultiple(string[] includes)
        {
            var data = _invoiceRepository.GetAll()
                .IncludeMultiple(includes).ToList();

            return data;
        }
    }
}

