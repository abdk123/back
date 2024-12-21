using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events
{
    public class ClearanceCompanyCashFlowCreateEventData : EventData
    {
        public ClearanceCompanyCashFlowCreateEventData(double amountDollar, double amountDinar, TransactionName transactionName, int? clearanceCompanyId, int? relatedId, string transactionDetails = "")
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            TransactionName = transactionName;
            ClearanceCompanyId = clearanceCompanyId;
            RelatedId = relatedId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? ClearanceCompanyId { get; set; }
        public int? RelatedId { get; set; }
    }
}
