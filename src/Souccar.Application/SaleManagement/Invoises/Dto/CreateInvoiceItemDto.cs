namespace Souccar.SaleManagement.Invoises.Dto
{
    public class CreateInvoiceItemDto
    {
        public double Quantity { get; set; }
        public int? OfferItemId { get; set; }
        public int? SupplierOfferItemId { get; set; }
        public double TotalMaterilPrice { get; set; }
        
    }
}
