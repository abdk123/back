using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public class SaleInvoiceDomainService : SouccarDomainService<SaleInvoice, int>, ISaleInvoiceDomainService
    {
        private readonly IRepository<SaleInvoice, int> _saleInvoiceRepository;
        private readonly IAppNotifier _appNotifier;
        public SaleInvoiceDomainService(IRepository<SaleInvoice, int> saleInvoiceRepository, IAppNotifier appNotifier) : base(saleInvoiceRepository)
        {
            _saleInvoiceRepository = saleInvoiceRepository;
            _appNotifier = appNotifier;
        }

        public async Task CheckSaleInvoiceAsync(Abp.UserIdentifier[] identifiers)
        {
                var saleInvoicesMustPaid = _saleInvoiceRepository.GetAllIncluding(c => c.Customer,x=>x.SaleInvoiceItems)
             .Where(x => x.DateForPaid.Date <= DateTime.Now.Date && x.PaidType == PaidType.NotPaid);
                if (saleInvoicesMustPaid.Any())
                {
                    foreach (var saleInvoice in saleInvoicesMustPaid)
                    {
                        if (!saleInvoice.Notified)
                        {
                        var title = "فاتورة مبيعات يجب دفعها من قبل الزبون " + saleInvoice.Customer.FullName;
                        var dic = new Dictionary<string, object>()
                        {
                            {"Id",saleInvoice.Id },
                            {"TotalQuantity",saleInvoice.InvoiceTotalQuantity },
                            {"DateForPaid",saleInvoice.DateForPaid },
                            {"Currency",saleInvoice.SaleCurrency },
                        };
                        await _appNotifier.SendSaleInvoiceNotify(title,dic,identifiers);
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
        }

        public async Task<SaleInvoice> GetWithDetailsByIdAsync(int saleInvoiceId)
        {
            return await _saleInvoiceRepository.GetAllIncluding(s => s.Customer)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m=>m.OfferItem).ThenInclude(f=>f.Material)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Unit)
                .Include(i => i.SaleInvoiceItems).ThenInclude(a => a.DeliveryItem)
                .ThenInclude(m => m.OfferItem).ThenInclude(f => f.Size)
                .FirstOrDefaultAsync(x => x.Id == saleInvoiceId);
        }
    }
}
