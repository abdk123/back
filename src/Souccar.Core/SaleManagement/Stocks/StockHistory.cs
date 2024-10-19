using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Stocks
{
    public class StockHistory : FullAuditedAggregateRoot
    {
        public StockType Type { get; set; }
        public StockReason Reason { get; set; }
        public string Title { get; set; }
        public double Quantity { get; set; }

        #region Stock
        public int? StockId { get; set; }

        [ForeignKey("StockId")]
        public Stock Stock { get; set; }
        #endregion
    }
}
