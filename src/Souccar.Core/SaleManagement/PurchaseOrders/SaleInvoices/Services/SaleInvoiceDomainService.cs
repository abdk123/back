using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Souccar.Authorization.Users;
using Souccar.Core.Services.Implements;
using Souccar.Notification;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public class SaleInvoiceDomainService : SouccarDomainService<SaleInvoice, int>, ISaleInvoiceDomainService
    {
        private readonly IRepository<SaleInvoice, int> _saleInvoiceRepository;
        private readonly IAppNotifier _appNotifier;
        private readonly UserManager _userManager;
        public SaleInvoiceDomainService(IRepository<SaleInvoice, int> saleInvoiceRepository, IAppNotifier appNotifier, UserManager userManager) : base(saleInvoiceRepository)
        {
            _saleInvoiceRepository = saleInvoiceRepository;
            _appNotifier = appNotifier;
            _userManager = userManager;
        }

        [UnitOfWork]
        public void CheckSaleInvoiceAsync()
        {
                var saleInvoicesMustPaid = _saleInvoiceRepository.GetAllIncluding(c => c.Customer,x=>x.SaleInvoiceItems)
             .Where(x => x.DateForPaid.Date <= DateTime.Now.Date && x.PaidType == PaidType.NotPaid);
                if (saleInvoicesMustPaid.Any())
                {
                    foreach (var saleInvoice in saleInvoicesMustPaid)
                    {
                        if (!saleInvoice.Notified)
                        {
                            _appNotifier.SendSaleInvoiceNotify(saleInvoice);
                            saleInvoice.Notified = true;
                            _saleInvoiceRepository.Update(saleInvoice);
                        }
                        else if (saleInvoice.Notified && saleInvoice.DateForPaid.Date < DateTime.Now.Date)
                        {
                            saleInvoice.Status = SaleInvoiceStatus.DelayInPaid;
                            _saleInvoiceRepository.Update(saleInvoice);
                        }
                    }
                
            }
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
