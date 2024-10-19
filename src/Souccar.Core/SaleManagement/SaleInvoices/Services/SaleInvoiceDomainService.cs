using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Notification;
using Souccar.SaleManagement.SaleInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.SaleInvoices.Services
{
    public class SaleInvoiceDomainService : SouccarDomainService<SaleInvoice, int>, ISaleInvoiceDomainService
    {
        private readonly IRepository<SaleInvoice, int> _saleInvoiceRepository;
        public SaleInvoiceDomainService(IRepository<SaleInvoice, int> saleInvoiceRepository) : base(saleInvoiceRepository)
        {
            _saleInvoiceRepository = saleInvoiceRepository;
        }

        public async Task<IList<SaleInvoice>> CheckSaleInvoiceAsync()
        {
            var saleInvoices = new List<SaleInvoice>();
            var saleInvoicesMustPaid = _saleInvoiceRepository.GetAllIncluding(c => c.Customer, x => x.SaleInvoiceItems)
         .Where(x => x.DateForPaid.Date <= DateTime.Now.Date && x.PaidType == PaidType.NotPaid);
            if (saleInvoicesMustPaid.Any())
            {
                foreach (var saleInvoice in saleInvoicesMustPaid)
                {
                    if (!saleInvoice.Notified)
                    {
                        saleInvoices.Add(saleInvoice);

                        saleInvoice.Notified = true;
                        await _saleInvoiceRepository.UpdateAsync(saleInvoice);
                    }
                    else if (saleInvoice.Notified && saleInvoice.DateForPaid.Date < DateTime.Now.Date)
                    {
                        saleInvoice.Status = SaleInvoiceStatus.DelayInPaid;
                        await _saleInvoiceRepository.UpdateAsync(saleInvoice);
                    }
                }
            }
            return saleInvoices;
        }

        public IList<SaleInvoice> GetByOfferItems(int[] offerItemsIds)
        {
            var data = _saleInvoiceRepository.GetAllIncluding(s => s.Customer)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Material)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Unit)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Size)
                .Where(x => x.SaleInvoiceItems.Any(i => offerItemsIds.Contains(i.DeliveryItem.OfferItemId.Value)));
            if (!data.Any())
            {
                return new List<SaleInvoice>();
            }
            return data.ToList();
        }

        public async Task<SaleInvoice> GetWithDetailsByIdAsync(int saleInvoiceId)
        {
            return await _saleInvoiceRepository.GetAllIncluding(s => s.Customer)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Material)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Unit)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Size)
                .FirstOrDefaultAsync(x => x.Id == saleInvoiceId);
        }


    }
}
