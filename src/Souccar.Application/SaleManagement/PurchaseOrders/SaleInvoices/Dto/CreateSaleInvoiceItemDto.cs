namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto
{
    public class CreateSaleInvoiceItemDto
    {
        public decimal TotalQuantity { get; set; }
        public int TotalItemPrice { get; set; }
        public int? SaleInvoiceId { get; set; }
        public int? DeliveryItemId { get; set; }
    }
}
