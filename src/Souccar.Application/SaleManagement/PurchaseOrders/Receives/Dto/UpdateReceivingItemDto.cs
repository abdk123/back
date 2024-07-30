using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Dto
{
    public class UpdateReceivingItemDto:EntityDto
    {
        public double ReceivedQuantity { get; set; }
        public int? InvoiceItemId { get; set; }
    }
}
