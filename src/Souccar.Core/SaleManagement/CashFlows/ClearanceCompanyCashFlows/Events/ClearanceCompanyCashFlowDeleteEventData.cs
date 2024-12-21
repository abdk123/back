using Abp.Events.Bus;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events
{
    public class ClearanceCompanyCashFlowDeleteEventData : EventData
    {
        public ClearanceCompanyCashFlowDeleteEventData(TransactionName transactionName, int? clearanceCompanyId, int? relatedId)
        {
            TransactionName = transactionName;
            ClearanceCompanyId = clearanceCompanyId;
            RelatedId = relatedId;
        }

        public TransactionName TransactionName { get; set; }
        public int? ClearanceCompanyId { get; set; }
        public int? RelatedId { get; set; }
    }
}
