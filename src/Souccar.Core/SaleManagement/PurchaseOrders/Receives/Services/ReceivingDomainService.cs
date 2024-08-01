using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using Souccar.SaleManagement.PurchaseOrders.Receives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Receivings.Services
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
            return _receivingRepository.GetAllIncluding(s=>s.Supplier,c=>c.ClearanceCompany,t=>t.TransportCompany)
                .Include(i => i.ReceivingItems).ThenInclude(x=>x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Where(x => x.InvoiceId == invoiceId);
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

