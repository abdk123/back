using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public class OfferDomainService : SouccarDomainService<Offer, int>, IOfferDomainService
    {
        private readonly IRepository<Offer,int> _offerRepository;
        private readonly IRepository<OfferItem> _offerItemRepository;
        public OfferDomainService(IRepository<Offer, int> offerRepository, IRepository<OfferItem> offerItemRepository = null) : base(offerRepository)
        {
            _offerRepository = offerRepository;
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

        public Offer GetOfferWithDetail(int offerId)
        {
            var offer = _offerRepository.GetAllIncluding(x => x.Customer, s => s.Supplier)
                .Include(x => x.OfferItems).ThenInclude(x => x.Material)
                .Include(x => x.OfferItems).ThenInclude(x => x.Unit)
                .Include(x => x.OfferItems).ThenInclude(x => x.Size)
                .FirstOrDefault(x=>x.Id == offerId);
            return offer;

        }
    }
}

