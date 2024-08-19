using Abp.Application.Services.Dto;
using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
    public class DeliveryItemDto: EntityDto
    {
        public string BatchNumber { get; set; }
        public double DeliveredQuantity { get; set; }
        public double TransportedQuantity { get; set; }
        public double ApprovedQuantity { get; set; }
        public double RejectedQuantity { get; set; }
        public InvoiceItemDto InvoiceItem { get; set; }
        public double ToralPrice { get; set; }
        public DeliveryItemStatus DeliveryItemStatus { get; set; }

    }
}
