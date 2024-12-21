using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events
{
    public class CustomerCashFlowDeleteEventData : EventData
    {
        public CustomerCashFlowDeleteEventData(TransactionName transactionName, int? customerId, int? relatedId)
        {
            TransactionName = transactionName;
            CustomerId = customerId;
            RelatedId = relatedId;
        }

        public TransactionName TransactionName { get; set; }
        public int? CustomerId { get; set; }
        public int? RelatedId { get; set; }
    }
}
