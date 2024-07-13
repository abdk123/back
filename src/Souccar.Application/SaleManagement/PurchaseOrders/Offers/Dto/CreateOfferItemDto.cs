namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
    public class CreateOfferItemDto
    {
        public int? MaterialId { get; set; }
        public int? SizeId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Specefecation { get; set; }
        public bool AddedBySmallUnit;
    }
}
