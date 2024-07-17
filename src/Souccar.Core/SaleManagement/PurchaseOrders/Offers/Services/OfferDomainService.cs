using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public class OfferDomainService : SouccarDomainService<Offer, int>, IOfferDomainService
    {
        private readonly IRepository<OfferItem> _offerItemRepository;
        public OfferDomainService(IRepository<Offer, int> offerRepository, IRepository<OfferItem> offerItemRepository = null) : base(offerRepository)
        {
            _offerItemRepository = offerItemRepository;
        }

        public IList<OfferItem> GetItemsByOfferId(int offerId)
        {
            var items = _offerItemRepository.GetAll().Where(x=>x.OfferId == offerId).ToList();
            return items;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await _offerItemRepository.DeleteAsync(itemId);
        }
    }
}

