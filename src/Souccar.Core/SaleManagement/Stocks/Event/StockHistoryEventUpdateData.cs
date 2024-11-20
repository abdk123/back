using Abp.Events.Bus;
using Souccar.SaleManagement.Stocks;

namespace Souccar.SaleManagement.StockHistories.Event
{
    public class StockHistoryEventUpdateData : EventData
    {
        public StockHistoryEventUpdateData(StockType type, StockReason reason, string title, double quantity, int? relatedId, int? unitId, int? sizeId, int? materialId)
        {
            Type = type;
            Reason = reason;
            Title = title;
            Quantity = quantity;
            UnitId = unitId;
            RelatedId = relatedId;
            SizeId = sizeId;
            MaterialId = materialId;
        }

        public StockType Type { get; set; }
        public StockReason Reason { get; set; }
        public string Title { get; set; }
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? SizeId { get; set; }
        public int? RelatedId { get; set; }
        public int? MaterialId { get; set; }
    }
}
