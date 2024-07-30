using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.PurchaseOrders.Receives;
using System.Linq;

namespace Souccar.SaleManagement.Receivings.Services
{
    public class ReceivingDomainService : SouccarDomainService<Receiving, int>, IReceivingDomainService
    {
        private readonly IRepository<Receiving, int> _receivingRepository;
        public ReceivingDomainService(IRepository<Receiving, int> receivingRepository) : base(receivingRepository)
        {
            _receivingRepository = receivingRepository;
        }

        public IQueryable<Receiving> GetAllByInvoiceId(int invoiceId)
        {
            return _receivingRepository.GetAllIncluding(s=>s.Supplier,c=>c.ClearanceCompany,t=>t.TransportCompany)
                .Include(i => i.ReceivingItems).ThenInclude(x=>x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.ReceivingItems).ThenInclude(x => x.InvoiceItem).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Where(x => x.InvoiceId == invoiceId);
        }
    }
}

