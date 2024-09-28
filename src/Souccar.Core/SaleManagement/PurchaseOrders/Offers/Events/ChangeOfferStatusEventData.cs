using Abp.Events.Bus;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Events
{
    public class ChangeOfferStatusEventData : EventData
    {
        public ChangeOfferStatusEventData(int offerId, OfferStatus status)
        {
            OfferId = offerId;
            Status = status;
        }

        public int OfferId { get; set; }
        public OfferStatus Status { get; set; }
    }
}
