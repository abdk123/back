using System;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowDeleteEventData : EventArgs
    {
        public TransportCompanyCashFlowDeleteEventData(double amountDollar, double amountDinar, string transactionDetails, string note, TransactionName transactionName, int? clearanceCompanyId)
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
