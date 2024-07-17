using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public interface IOfferDomainService : ISouccarDomainService<Offer, int>
    {
        IList<OfferItem> GetItemsByOfferId(int offerId);
        Task DeleteItemAsync(int itemId);
    }
}

