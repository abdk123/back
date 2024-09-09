using Abp.Domain.Entities;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries
{
    public class DeliveryItem : Entity
    {
        public string BatchNumber { get; set; }
        public double DeliveredQuantity { get; set; }
        public double ApprovedQuantity { get; set; }
        public double RejectedQuantity { get; set; }
        public double TotalPrice
        {
            get
            {
                if (OfferItem != null)
                {
                    return OfferItem.UnitPrice * ApprovedQuantity;
                }
                return 0;
            }
        }
        public DeliveryItemStatus DeliveryItemStatus { get; set; }

        #region Delivery
        public int? DeliveryId { get; set; }

        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; }
        #endregion

        #region Offer Item
        public int? OfferItemId { get; set; }

        [ForeignKey(nameof(OfferItemId))]
        public OfferItem OfferItem { get; set; }
        #endregion
    }
}
