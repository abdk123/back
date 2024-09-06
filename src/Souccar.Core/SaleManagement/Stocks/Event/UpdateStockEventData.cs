using Abp.Events.Bus;

namespace Souccar.SaleManagement.Stocks.Event
{
    public class UpdateStockEventData : EventData
    {
        public UpdateStockEventData(int? materialId, double numberInLargeUnit = 0, double numberInSmallUnit = 0, double damagedNumberInLargeUnit = 0, double damagedNumberInSmallUnit = 0)
        {
            MaterialId = materialId;
            NumberInLargeUnit = numberInLargeUnit;
            NumberInSmallUnit = numberInSmallUnit;
            DamagedNumberInLargeUnit = damagedNumberInLargeUnit;
            DamagedNumberInSmallUnit = damagedNumberInSmallUnit;
        }

        public int? MaterialId { get; set; }
        public double NumberInLargeUnit { get; set; }
        public double NumberInSmallUnit { get; set; }
        public double DamagedNumberInLargeUnit { get; set; }
        public double DamagedNumberInSmallUnit { get; set; }
    }
}
