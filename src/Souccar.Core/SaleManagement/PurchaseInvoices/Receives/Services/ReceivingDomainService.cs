using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseInvoices.Receives.Services
{
    public class ReceivingDomainService : SouccarDomainService<Receiving, int>, IReceivingDomainService
    {
        private readonly IRepository<Receiving, int> _receivingRepository;
        private readonly IRepository<ReceivingItem, int> _receivingItemRepository;
        public ReceivingDomainService(IRepository<Receiving, int> receivingRepository, IRepository<ReceivingItem, int> receivingItemRepository = null) : base(receivingRepository)
        {
            _receivingRepository = receivingRepository;
            _receivingItemRepository = receivingItemRepository;
        }

        public IQueryable<Receiving> GetAllByInvoiceId(int invoiceId)
        {
            return _receivingRepository.GetAllIncluding(c => c.ClearanceCompany, t => t.TransportCompany)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Supplier)
                .Where(x => x.InvoiceId == invoiceId);
        }

        public IQueryable<Receiving> GetAllByInvoicesIds(int[] invoicesIds)
        {
            return _receivingRepository.GetAllIncluding(c => c.ClearanceCompany, t => t.TransportCompany)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Supplier)
                .Where(x => invoicesIds.Contains(x.InvoiceId.Value));
        }

        public IList<ReceivingItem> GetItemsByReceivingId(int receivingId)
        {
            var items = _receivingItemRepository.GetAll().Where(x => x.ReceivingId == receivingId).ToList();
            return items;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await _receivingItemRepository.DeleteAsync(itemId);
        }

        
    }
}

