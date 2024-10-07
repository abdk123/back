using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events
{
    public class CustomerCashFlowUpdateEventData : EventData
    {
        public CustomerCashFlowUpdateEventData(double amountDollar, double amountDinar, TransactionName transactionName, int? clearanceCompanyId, int? relatedId = null, string transactionDetails = "", string note = "")
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            Note = note;
            TransactionName = transactionName;
            CustomerId = clearanceCompanyId;
            RelatedId = relatedId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? CustomerId { get; set; }
        public int? RelatedId { get; set; }
    }
}
