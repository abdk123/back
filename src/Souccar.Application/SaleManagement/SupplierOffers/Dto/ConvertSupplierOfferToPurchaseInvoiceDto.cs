using System.Collections.Generic;

namespace Souccar.SaleManagement.SupplierOffers.Dto
{
    public class ConvertSupplierOfferToPurchaseInvoiceDto
    {
        public int SupplierId { get; set; }
        public int OfferId { get; set; }
        public IList<int> OfferItemsIds { get; set; }
    }
}
