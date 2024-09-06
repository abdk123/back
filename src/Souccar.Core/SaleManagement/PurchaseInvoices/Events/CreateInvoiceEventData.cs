using Abp.Events.Bus;
using Souccar.SaleManagement.Settings.Currencies;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseInvoices.Events
{
    public class CreateInvoiceEventData : EventData
    {
        public CreateInvoiceEventData(int supplierId, int offerId, IList<int> offerItemsIds, Currency currency)
        {
            SupplierId = supplierId;
            OfferId = offerId;
            OfferItemsIds = offerItemsIds;
            Currency = currency;
        }

        public int SupplierId { get; set; }
        public int OfferId { get; set; }
        public Currency Currency { get; set; }
        public IList<int> OfferItemsIds { get; set; }
    }
}
