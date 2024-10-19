using System;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class RejectDeliveryDto
    {
        public int DeliveryId { get; set; }
        public int DeliveryItemId { get; set; }
        public double RejectedQuantity { get; set; }
        public bool ReturnToSupplier { get; set; }
        public DateTime? RejectionDate { get; set; }

    }
}
