using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public class OfferAppService :
        AsyncSouccarAppService<Offer, OfferDto, int, FullPagedRequestDto, CreateOfferDto, UpdateOfferDto>, IOfferAppService
    {
        private readonly IOfferDomainService _offerDomainService;

        public OfferAppService(IOfferDomainService offerDomainService)
        : base(offerDomainService)
        {
            _offerDomainService = offerDomainService;
        }

        
    }
}

