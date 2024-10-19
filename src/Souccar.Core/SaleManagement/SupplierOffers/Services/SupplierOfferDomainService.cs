using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.SupplierOffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.SupplierOffers.Services
{
    public class SupplierOfferDomainService : SouccarDomainService<SupplierOffer, int>, ISupplierOfferDomainService
    {
        private readonly IRepository<SupplierOffer, int> _offerRepository;
        private readonly IRepository<SupplierOfferItem> _offerItemRepository;
        public SupplierOfferDomainService(IRepository<SupplierOffer, int> offerRepository, IRepository<SupplierOfferItem> offerItemRepository = null) : base(offerRepository)
        {
            _offerRepository = offerRepository;
            _offerItemRepository = offerItemRepository;
        }

        public IList<SupplierOfferItem> GetItemsBySupplierOfferId(int offerId)
        {
            var items = _offerItemRepository.GetAll().Where(x => x.SupplierOfferId == offerId).ToList();
            return items;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await _offerItemRepository.DeleteAsync(itemId);
        }

        public SupplierOffer GetSupplierOfferWithDetail(int offerId)
        {
            var offer = _offerRepository.GetAllIncluding(x => x.PurchaseInvoices)
                .Include(x => x.SupplierOfferItems).ThenInclude(x => x.Material)
                .Include(x => x.SupplierOfferItems).ThenInclude(x => x.Unit)
                .Include(x => x.SupplierOfferItems).ThenInclude(x => x.Size)
                .Include(x => x.SupplierOfferItems).ThenInclude(x => x.Supplier)
                .FirstOrDefault(x => x.Id == offerId);
            return offer;

        }

        public async Task<string> GetPoForBySupplierOfferItemId(int offerItemId)
        {
            var offer = await _offerRepository.GetAll()
                .Where(x => x.SupplierOfferItems.Any(z => z.Id == offerItemId))
                .FirstOrDefaultAsync();
            return offer != null ? offer.PorchaseOrderId : "";
        }

        public async Task<SupplierOfferItem> GetItemById(int? itemId)
        {
            return await _offerItemRepository.GetAsync(itemId.Value);
        }


    }
}

