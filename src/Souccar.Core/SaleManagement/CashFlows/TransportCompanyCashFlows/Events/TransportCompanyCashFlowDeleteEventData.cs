using Abp.Events.Bus;
using System;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events
{
    public class TransportCompanyCashFlowDeleteEventData : EventData
    {
        public TransportCompanyCashFlowDeleteEventData(TransactionName transactionName, int? transportCompanyId, int? relatedId)
        {
            TransactionName = transactionName;
            TransportCompanyId = transportCompanyId;
            RelatedId = relatedId;
        }

        public TransactionName TransactionName { get; set; }
        public int? TransportCompanyId { get; set; }
        public int? RelatedId { get; set; }
    }
}
