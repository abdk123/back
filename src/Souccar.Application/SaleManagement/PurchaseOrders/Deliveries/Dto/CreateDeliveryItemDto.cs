namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
    public class CreateDeliveryItemDto
    {
        public string BatchNumber { get; set; }
        public int? InvoiceItemId { get; set; }
        public double DeliveredQuantity { get; set; }
    }
}
