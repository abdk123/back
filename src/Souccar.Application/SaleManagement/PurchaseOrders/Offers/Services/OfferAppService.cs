using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public IList<UpdateOfferItemDto> GetItemsByOfferId(int offerId)
        {
            var items = _offerDomainService.GetItemsByOfferId(offerId);
            return ObjectMapper.Map<IList<UpdateOfferItemDto>>(items);
        }

        public override async Task<OfferDto> UpdateAsync(UpdateOfferDto input)
        {
            var oldOffer = await _offerDomainService.GetAsync(input.Id);
            ObjectMapper.Map<UpdateOfferDto, Offer>(input, oldOffer);
            var newOffer = await _offerDomainService.UpdateAsync(oldOffer);
            var items = await Task.FromResult(_offerDomainService.GetItemsByOfferId(oldOffer.Id));
            foreach(var item in items)
            {
                if(!input.OfferItems.Any(x=>x.Id == item.Id))
                {
                  await _offerDomainService.DeleteItemAsync(item.Id);
                }
            }
            return ObjectMapper.Map<OfferDto>(newOffer);

        }
    }
}

