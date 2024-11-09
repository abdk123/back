using System;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Souccar.SaleManagement.Offers;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Deliveries
{
    public class DeliveryItem : Entity
    {
        public DeliveryItem()
        {
            RejectedMaterials = new List<RejectedMaterial>();
        }
        public string BatchNumber { get; set; }
        public double DeliveredQuantity { get; set; }
        public double ApprovedQuantity { get; set; }
        public double RejectedQuantity { get; set; }
        public DateTime? RejectionDate { get; set; }
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

        public IList<RejectedMaterial> RejectedMaterials {  get; set; }
    }
}
