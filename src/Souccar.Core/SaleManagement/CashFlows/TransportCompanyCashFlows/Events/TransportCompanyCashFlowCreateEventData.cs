using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowCreateEventData : EventData
    {
        public TransportCompanyCashFlowCreateEventData(double amountDollar, double amountDinar, TransactionName transactionName, int? transportCompanyId, int? relatedId = null, string transactionDetails = "")
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            TransactionName = transactionName;
            TransportCompanyId = transportCompanyId;
            RelatedId = relatedId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? TransportCompanyId { get; set; }
        public int? RelatedId { get; set; }
    }
}
