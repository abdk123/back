using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Deliveries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Deliveries.Services
{
    public class DeliveryDomainService : SouccarDomainService<Delivery, int>, IDeliveryDomainService
    {
        private readonly IRepository<Delivery, int> _deliveryRepository;
        private readonly IRepository<DeliveryItem, int> _deliveryItemRepository;
        private readonly IRepository<RejectedMaterial, int> _rejectedMaterialRepository;

        public DeliveryDomainService(IRepository<Delivery, int> deliveryRepository, IRepository<DeliveryItem, int> deliveryItemRepository, IRepository<RejectedMaterial, int> rejectedMaterialRepository) : base(deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
            _deliveryItemRepository = deliveryItemRepository;
            _rejectedMaterialRepository = rejectedMaterialRepository;
        }

        public async Task<Delivery> GetWithDetailsByIdAsync(int id)
        {
            var delivery =
                await _deliveryRepository.GetAll().AsNoTracking()
                .Include(c => c.Customer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(of => of.Offer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(m => m.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .FirstOrDefaultAsync(z => z.Id == id);
            return delivery;
        }

        public IQueryable<Delivery> GetAllByCustomerId(int customerId)
        {
            return _deliveryRepository.GetAllIncluding(s => s.Customer)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Where(x => x.CustomerId == customerId);
        }

        public async Task<IQueryable<Delivery>> GetAllDeliverdAsync()
        {
            var deliveries = await Task.FromResult(_deliveryRepository.GetAllIncluding(x => x.Customer)
                .Include(z => z.DeliveryItems).ThenInclude(s => s.OfferItem).ThenInclude(a => a.Offer)
                .Where(c => c.Status == DeliveryStatus.Approved || c.Status == DeliveryStatus.PartialRejected));
            return deliveries;
        }
        public IQueryable<Delivery> GetAllWithDetail()
        {
            return _deliveryRepository.GetAllIncluding(s => s.Customer)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size);
        }

        public async Task<DeliveryItem> ChangeItemStatusAsync(int id, int status)
        {
            var deliveryItem = await _deliveryItemRepository.GetAsync(id);
            if (deliveryItem == null)
            {
                throw new UserFriendlyException("Delivery Item Not Found");
            }

            deliveryItem.DeliveryItemStatus = (DeliveryItemStatus)status;
            if (deliveryItem.DeliveryItemStatus == DeliveryItemStatus.Rejected)
            {
                deliveryItem.RejectedQuantity = deliveryItem.DeliveredQuantity;
            }
            return await _deliveryItemRepository.UpdateAsync(deliveryItem);
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

        public IQueryable<Delivery> GetForSaleInvoice(int customerId)
        {
            return _deliveryRepository.GetAll().AsNoTracking()
                .Include(c => c.Customer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(of => of.Offer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(m => m.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Where(x => x.CustomerId == customerId && x.Status != DeliveryStatus.WaitingApprove && x.Status != DeliveryStatus.PartialRejected && x.Status != DeliveryStatus.Rejected);

        }

        public IQueryable<Delivery> GetByOfferItems(int[] offerItemIds)
        {
            return _deliveryRepository.GetAll().AsNoTracking()
                .Include(c => c.Customer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(of => of.Offer)
                .Include(i => i.DeliveryItems).ThenInclude(inv => inv.OfferItem).ThenInclude(m => m.Material).ThenInclude(x => x.Stocks)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Unit)
                .Include(i => i.DeliveryItems).ThenInclude(x => x.OfferItem).ThenInclude(x => x.Size)
                .Where(x => x.DeliveryItems.Any(d => offerItemIds.Contains(d.OfferItemId.Value)));
        }

        public async Task<IList<RejectedMaterial>> CreateRejectedMaterials(List<RejectedMaterial> rejectedMaterials)
        {
            var updatedItems = new List<RejectedMaterial>();
            foreach (var item in rejectedMaterials)
            {
                var updatedItem = await _rejectedMaterialRepository.UpdateAsync(item);
                updatedItems.Add(updatedItem);
            }
            return updatedItems;
        }

        public DeliveryItem GetItemById(int? itemId)
        {
            var deliveryItem = _deliveryItemRepository.GetAllIncluding(x => x.Delivery)
                .Include(x=>x.OfferItem).ThenInclude(x=>x.Material)
                .Include(x=>x.OfferItem).ThenInclude(x=>x.Unit)
                .Include(x=>x.OfferItem).ThenInclude(x=>x.Size)
                .FirstOrDefault(x => x.Id == itemId);
            return deliveryItem;
        }
    }
}

