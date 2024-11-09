using Abp.Domain.Entities;
using Souccar.SaleManagement.Settings.Customers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Deliveries
{
    public class RejectedMaterial: Entity
    {
        public DateTime? RejectionDate { get; set; }
        public MaterialSource MaterialSource { get; set; }
        public double RejectedQuantity { get; set; }
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }

        public int? DeliveryItemId { get; set; }

        [ForeignKey(nameof(DeliveryItemId))]
        public DeliveryItem DeliveryItem { get; set; }
    }
}
