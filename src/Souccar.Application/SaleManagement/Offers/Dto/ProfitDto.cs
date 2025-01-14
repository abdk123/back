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
        public double TotalTransportCost => ProfitItems.Sum(x => x.TransportCost);
        public double TotalClearanceCost => ProfitItems.Sum(x => x.ClearanceCost);
        public double ProfitValue
        {
            get
            {
                var value = TotalSellingPrice - (TotalPurchasePrice + TotalTransportCost + TotalClearanceCost);
                return value > 0 ? value : 0;
            }
        }
    }

    public class ProfitItemDto
    {
        public ProfitItemDto(int offerItemId, string materialName, double deliveredQuantity, double sellingPrice, double purchasePrice, double transportCost, double clearanceCost)
        {
            OfferItemId = offerItemId;
            MaterialName = materialName;
            DeliveredQuantity = deliveredQuantity;
            SellingPrice = sellingPrice;
            PurchasePrice = purchasePrice;
            TransportCost = transportCost;
            ClearanceCost = clearanceCost;
        }

        public int OfferItemId { get; set; }
        public string MaterialName { get; set; }
        public double DeliveredQuantity { get; set; }
        public double SellingPrice { get; set; }
        public double PurchasePrice { get; set; }
        public double TransportCost { get; set; }
        public double ClearanceCost { get; set; }
    }
}
