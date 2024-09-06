namespace Souccar.SaleManagement.Invoises.Dto
{
    public class InvoiceItemForDeliveryDto
    {
        public int InvoiceId { get; set; }
        public int InvoiceItemId { get; set; }
        public string MaterialName { get; set; }
        public double RequiredQuantity { get; set; }
        public double TotalMaterilPrice { get; set; }
        public double ReceivedQuantity { get; set; }
        public double DeliveredQuantity { get; set; }
        public double NumberInSmallUnit { get; set; }
        public bool AddedBySmallUnit { get; set; }
        public string Unit { get; set; }
        public string SmallUnit { get; set; }
        public string PoNumber { get; set; }

    }
}
