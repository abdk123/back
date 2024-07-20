using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events
{
    public class CustomerCashFlowDeleteEventData : EventData
    {
        public CustomerCashFlowDeleteEventData(double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName, int? customerId)
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            Note = note;
            TransactionName = transactionName;
            CustomerId = customerId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? CustomerId { get; set; }
    }
}
