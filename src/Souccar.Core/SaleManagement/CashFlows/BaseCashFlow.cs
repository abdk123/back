using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.CashFlows;

namespace Souccar.SaleManagement.CachFlows
{
    public class BaseCashFlow : FullAuditedAggregateRoot
    {
        public double AmountDollar { get; set; }
        public double CurrentBalanceDollar { get; set; }
        public double AmountDinar { get; set; }
        public double CurrentBalanceDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? RelatedId { get; set; }
    }
}
