using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
    public class UpdateDeliveryItemDto: EntityDto
    {
        public string BatchNumber { get; set; }
        public int? InvoiceItemId { get; set; }
        public double DeliveredQuantity { get; set; }
    }
}
