using Abp.Events.Bus;
using Souccar.SaleManagement.Stocks;

namespace Souccar.SaleManagement.StockHistories.Event
{
    public class StockHistoryEventCreateData : EventData
    {
        public StockHistoryEventCreateData(StockType type, StockReason reason, string title, double quantity, int? stockId)
        {
            Type = type;
            Reason = reason;
            Title = title;
            Quantity = quantity;
            StockId = stockId;
        }

        public StockType Type { get; set; }
        public StockReason Reason { get; set; }
        public string Title { get; set; }
        public double Quantity { get; set; }
        public int? StockId { get; set; }
    }
}
