namespace Souccar.SaleManagement.Offers.Dto
{
    public class CreateOfferItemDto
    {
        public string MaterialName { get; set; }
        public string UnitName { get; set; }
        public int? MaterialId { get; set; }
        public int? SizeId { get; set; }
        public int? UnitId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Specefecation { get; set; }
        public bool AddedBySmallUnit { get; set; }
    }
}
