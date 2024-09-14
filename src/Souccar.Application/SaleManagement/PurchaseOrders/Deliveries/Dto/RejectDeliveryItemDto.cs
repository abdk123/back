using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;
using Souccar.SaleManagement.Settings.Currencies;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
    public class RejectDeliveryItemDto : EntityDto
    {
        public int? DeliveryId { get; set; }
        public string BatchNumber { get; set; }
        public double DeliveredQuantity { get; set; }
        public double ApprovedQuantity { get; set; }
        public double RejectedQuantity { get; set; }
        public double TotalPrice { get; set; }
        public DeliveryItemStatus DeliveryItemStatus { get; set; }
        public OfferItemDto OfferItem { get; set; }
        public string PoNumber => OfferItem?.Offer?.PorchaseOrderId ?? string.Empty;
        public int Currncy => (int)OfferItem.Offer.Currency;
        public string SizeName => OfferItem?.Size?.Name ?? string.Empty;
        public string UnitName => OfferItem?.Unit?.Name ?? SizeName;
        public string MaterialName => OfferItem?.Material?.Name ?? string.Empty;

    }
}
