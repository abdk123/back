using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public class OfferDomainService : SouccarDomainService<Offer, int>, IOfferDomainService
    {
        public OfferDomainService(IRepository<Offer, int> offerRepository) : base(offerRepository)
        {
        }
    }
}

