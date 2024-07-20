using Abp.Events.Bus;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Events
{
    public class CreateInvoiceEventData :EventData
    {
        public int OfferId { get; set; }
        public IList<OfferItem> OfferItems { get; set; }
    }
}
