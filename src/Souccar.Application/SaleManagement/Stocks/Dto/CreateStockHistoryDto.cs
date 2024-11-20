namespace Souccar.SaleManagement.Stocks.Dto
{
    public class CreateStockHistoryDto
    {
        public StockType Type { get; set; }
        public StockReason Reason { get; set; }
        public string Title { get; set; }
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? SizeId { get; set; }
    }
}
