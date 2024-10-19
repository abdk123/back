using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.SupplierOffers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.SupplierOffers.Services
{
    public interface ISupplierOfferDomainService : ISouccarDomainService<SupplierOffer, int>
    {
        IList<SupplierOfferItem> GetItemsBySupplierOfferId(int offerId);
        Task DeleteItemAsync(int itemId);
        SupplierOffer GetSupplierOfferWithDetail(int offerId);
        Task<string> GetPoForBySupplierOfferItemId(int offerItemId);
        Task<SupplierOfferItem> GetItemById(int? itemId);
    }
}

