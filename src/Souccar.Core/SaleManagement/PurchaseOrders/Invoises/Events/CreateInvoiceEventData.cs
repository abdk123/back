using Abp.Events.Bus;
using Souccar.SaleManagement.PurchaseOrders.Offers;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Events
{
    public class CreateInvoiceEventData :EventData
    {
        public Offer Offer { get; set; }

        public CreateInvoiceEventData(Offer offer)
        {
            Offer = offer;
        }
    }
}
