using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Deliveries.Dto;

namespace Souccar.SaleManagement.SaleInvoices.Dto
{
    public class SaleInvoiceItemDto : EntityDto
    {
        public decimal TotalQuantity { get; set; }
        public int TotalItemPrice { get; set; }
        public int? SaleInvoiceId { get; set; }


        #region DeliveryItem
        public int? DeliveryItemId { get; set; }
        public DeliveryItemDto DeliveryItem { get; set; }
        #endregion
    }
}
