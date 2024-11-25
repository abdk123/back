using Abp.Events.Bus;
using Souccar.SaleManagement.Stocks;

namespace Souccar.SaleManagement.StockHistories.Event
{
    public class StockHistoryEventDeleteData : EventData
    {
        public StockHistoryEventDeleteData(StockType type, StockReason reason, int? relatedId)
        {
            Type = type;
            Reason = reason;
            RelatedId = relatedId;
        }

        public StockType Type { get; set; }
        public StockReason Reason { get; set; }
        public int? RelatedId { get; set; }
    }
}
