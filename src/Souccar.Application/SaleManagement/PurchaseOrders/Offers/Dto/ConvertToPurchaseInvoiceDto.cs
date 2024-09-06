using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
    public class ConvertToPurchaseInvoiceDto
    {
        public int SupplierId { get; set; }
        public int OfferId { get; set; }
        public IList<int> OfferItemsIds { get; set; }
    }
}
