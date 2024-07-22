using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowCreateEventData : EventData
    {
        public TransportCompanyCashFlowCreateEventData(double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName, int? transportCompanyId)
        {
            AmountDollar = amountDollar;
            AmountDinar = amountDinar;
            TransactionDetails = transactionDetails;
            Note = note;
            TransactionName = transactionName;
            TransportCompanyId = transportCompanyId;
        }

        public double AmountDollar { get; set; }
        public double AmountDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? TransportCompanyId { get; set; }
    }
}
