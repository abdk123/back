using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events
{
    public class ClearanceCompanyCashFlowCreateEventData : EventData
    {
        public ClearanceCompanyCashFlowCreateEventData(double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName, int? clearanceCompanyId)
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            Note = note;
            TransactionName = transactionName;
            ClearanceCompanyId = clearanceCompanyId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? ClearanceCompanyId { get; set; }
    }
}
