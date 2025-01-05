using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.SaleManagement.Offers.Dto
{
    public class ProfitDto
    {
        public ProfitDto(int offerId)
        {
            ProfitItems = new List<ProfitItemDto>();
            OfferId = offerId;
        }
        public int OfferId { get; set; }
        public double TotalSellingPrice => ProfitItems.Sum(x => x.SellingPrice);
        public double TotalPurchasePrice => ProfitItems.Sum(x => x.PurchasePrice);
        public IList<ProfitItemDto> ProfitItems { get; set; }
    }

    public class ProfitItemDto
    {
        public ProfitItemDto(int offerItemId, string materialName, double deliveredQuantity, double sellingPrice, double purchasePrice)
        {
            OfferItemId = offerItemId;
            MaterialName = materialName;
            SellingPrice = sellingPrice;
            PurchasePrice = purchasePrice;
        }

        public int OfferItemId { get; set; }
        public string MaterialName { get; set; }
        public double DeliveredQuantity { get; set; }
        public double SellingPrice { get; set; }
        public double PurchasePrice { get; set; }
    }
}
