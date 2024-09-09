using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public class OfferDomainService : SouccarDomainService<Offer, int>, IOfferDomainService
    {
        private readonly IRepository<Offer, int> _offerRepository;
        private readonly IRepository<OfferItem> _offerItemRepository;
        public OfferDomainService(IRepository<Offer, int> offerRepository, IRepository<OfferItem> offerItemRepository = null) : base(offerRepository)
        {
            _offerRepository = offerRepository;
            _offerItemRepository = offerItemRepository;
        }

        public IList<OfferItem> GetItemsByOfferId(int offerId)
        {
            var items = _offerItemRepository.GetAll().Where(x => x.OfferId == offerId).ToList();
            return items;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await _offerItemRepository.DeleteAsync(itemId);
        }

        public Offer GetOfferWithDetail(int offerId)
        {
            var offer = _offerRepository.GetAllIncluding(x => x.Customer)
                .Include(x => x.OfferItems).ThenInclude(x => x.Material)
                .Include(x => x.OfferItems).ThenInclude(x => x.Unit)
                .Include(x => x.OfferItems).ThenInclude(x => x.Size)
                .Include(x => x.OfferItems).ThenInclude(x => x.Supplier)
                .FirstOrDefault(x => x.Id == offerId);
            return offer;

        }

        public async Task<string> GetPoForByOfferItemId(int offerItemId)
        {
            var offer = await _offerRepository.GetAll()
                .Where(x => x.OfferItems.Any(z => z.Id == offerItemId))
                .FirstOrDefaultAsync();
            return offer != null ? offer.PorchaseOrderId : "";
        }

        public async Task<OfferItem> GetItemById(int? itemId)
        {
            return await _offerItemRepository.GetAsync(itemId.Value);
        }

        public IList<OfferItem> GetForDelivery(int customerId)
        {
            var offers = _offerRepository.GetAll()
                .Include(o => o.OfferItems).ThenInclude(o => o.DeliveryItems)
                .Include(o => o.OfferItems).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks).ThenInclude(x => x.Size)
                .Include(o => o.OfferItems).ThenInclude(x => x.Material).ThenInclude(x => x.Stocks).ThenInclude(x => x.Unit)
                .Where(x => x.CustomerId == customerId).ToList();
            return offers.SelectMany(x=>x.OfferItems).Where(x=>x.Quantity > x.DeliveredQuantity).ToList();
        }
    }
}

