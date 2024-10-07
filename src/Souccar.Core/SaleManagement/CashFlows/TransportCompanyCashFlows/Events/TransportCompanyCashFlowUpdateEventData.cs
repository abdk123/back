using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowUpdateEventData : EventData
    {
        public TransportCompanyCashFlowUpdateEventData(double amountDollar, double amountDinar, TransactionName transactionName, int? transportCompanyId, int? relatedId = null, string transactionDetails = "", string note = "")
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            Note = note;
            TransactionName = transactionName;
            TransportCompanyId = transportCompanyId;
            RelatedId = relatedId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? TransportCompanyId { get; set; }
        public int? RelatedId { get; set; }
    }
}
