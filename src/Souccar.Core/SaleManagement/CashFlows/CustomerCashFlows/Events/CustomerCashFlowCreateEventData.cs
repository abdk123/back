using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events
{
    public class CustomerCashFlowCreateEventData : EventData
    {
        public CustomerCashFlowCreateEventData(double amountDollar, double amountDinar, TransactionName transactionName, int? customerId, int? relatedId = null, string transactionDetails = "")
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            TransactionName = transactionName;
            CustomerId = customerId;
            RelatedId = relatedId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? CustomerId { get; set; }
        public int? RelatedId { get; set; }
    }
}
