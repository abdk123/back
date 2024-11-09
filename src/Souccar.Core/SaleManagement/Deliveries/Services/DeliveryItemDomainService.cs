using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Deliveries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Deliveries.Services
{
    public class DeliveryItemDomainService : SouccarDomainService<DeliveryItem, int>, IDeliveryItemDomainService
    {
        private readonly IRepository<Delivery, int> _deliveryRepository;
        private readonly IRepository<DeliveryItem, int> _deliveryItemRepository;

        public DeliveryItemDomainService(IRepository<Delivery, int> deliveryRepository, IRepository<DeliveryItem, int> deliveryItemRepository) : base(deliveryItemRepository)
        {
            _deliveryRepository = deliveryRepository;
            _deliveryItemRepository = deliveryItemRepository;
        }

        public Task<RejectedMaterial> CreateList(List<RejectedMaterial> rejectedMaterials)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Delivery> GetAllRejected()
        {
            return _deliveryRepository.GetAll().AsNoTracking()
                .Include(c => c.Customer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(of => of.Offer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(m => m.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Where(x => x.Status == DeliveryStatus.PartialRejected || x.Status == DeliveryStatus.Rejected);
        }
    }
}

