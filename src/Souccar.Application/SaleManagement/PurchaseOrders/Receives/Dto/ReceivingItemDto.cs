using Abp.Application.Services.Dto;
using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Dto
{
    public class ReceivingItemDto : EntityDto
    {
        public double ReceivedQuantity { get; set; }
        public int? InvoiceItemId { get; set; }
    }
}
