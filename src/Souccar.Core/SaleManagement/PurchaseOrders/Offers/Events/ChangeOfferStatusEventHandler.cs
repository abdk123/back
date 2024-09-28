using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.PurchaseOrders.Offers.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Events
{
    public class ChangeOfferStatusEventHandler : IAsyncEventHandler<ChangeOfferStatusEventData>, ITransientDependency
    {
        private readonly IOfferDomainService _offerDomainService;

        public ChangeOfferStatusEventHandler(IOfferDomainService offerDomainService)
        {
            _offerDomainService = offerDomainService;
        }

        public async Task HandleEventAsync(ChangeOfferStatusEventData eventData)
        {
            var offer = await _offerDomainService.GetAsync(eventData.OfferId);
            offer.Status = eventData.Status;
            await _offerDomainService.UpdateAsync(offer);
        }
    }
}
