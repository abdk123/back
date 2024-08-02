using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public class DeliveryDomainService : SouccarDomainService<Delivery, int>, IDeliveryDomainService
    {
        private readonly IRepository<Delivery, int> _deliveryRepository;
        public DeliveryDomainService(IRepository<Delivery, int> deliveryRepository) : base(deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<Delivery> GetWithDetailsByIdAsync(int id)
        {
            var delivery =
                await _deliveryRepository.GetAll()
                .Include(c => c.Customer).
                Include(i => i.DeliveryItems).ThenInclude(inv => inv.InvoiceItem)
                .ThenInclude(ofi => ofi.OfferItem).ThenInclude(of => of.Offer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.InvoiceItem)
                .ThenInclude(ofi=>ofi.OfferItem).ThenInclude(m=>m.Material)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.InvoiceItem)
                .ThenInclude(ofii => ofii.OfferItem).ThenInclude(u=>u.Unit)
                .FirstOrDefaultAsync(z => z.Id == id);
            return delivery;
        }

    }
}

