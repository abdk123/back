﻿namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class CreateDeliveryItemDto
    {
        public string BatchNumber { get; set; }
        public int? OfferItemId { get; set; }
        public double DeliveredQuantity { get; set; }
    }
}
