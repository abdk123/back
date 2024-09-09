using Abp.Application.Services.Dto;
using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
    public class DeliveryItemDto: EntityDto
    {
        public string BatchNumber { get; set; }
        public double DeliveredQuantity { get; set; }
        public double ApprovedQuantity { get; set; }
        public double RejectedQuantity { get; set; }
        public OfferItemDto OfferItem { get; set; }
        public double TotalPrice { get; set; }
        public DeliveryItemStatus DeliveryItemStatus { get; set; }

    }
}
