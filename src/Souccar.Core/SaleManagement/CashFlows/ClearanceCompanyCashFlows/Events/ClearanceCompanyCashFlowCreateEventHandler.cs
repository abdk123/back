using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events
{
    public class ClearanceCompanyCashFlowCreateEventHandler : IAsyncEventHandler<ClearanceCompanyCashFlowCreateEventData>, ITransientDependency
    {
        private readonly IClearanceCompanyCashFlowDomainService _clearanceCompanyCashFlowDomainService;

        public ClearanceCompanyCashFlowCreateEventHandler(IClearanceCompanyCashFlowDomainService clearanceCompanyCashFlowDomainService)
        {
            _clearanceCompanyCashFlowDomainService = clearanceCompanyCashFlowDomainService;
        }

        public async Task HandleEventAsync(ClearanceCompanyCashFlowCreateEventData eventData)
        {
            var cashFlow = await _clearanceCompanyCashFlowDomainService.GetCashFlow(eventData.ClearanceCompanyId, eventData.RelatedId, eventData.TransactionName);
            if (cashFlow != null)
            {
                cashFlow.RelatedId = eventData.RelatedId;
                cashFlow.AmountDinar = eventData.AmountDinar;
                cashFlow.AmountDollar = eventData.AmountDollar;
                cashFlow.ClearanceCompanyId = eventData.ClearanceCompanyId;
                cashFlow.TransactionName = eventData.TransactionName;
                cashFlow.TransactionDetails = eventData.TransactionDetails;
                await _clearanceCompanyCashFlowDomainService.UpdateAsync(cashFlow);
            }
            else
            {
                var clearanceCompanyCashFlow = new ClearanceCompanyCashFlow()
                {
                    RelatedId = eventData.RelatedId,
                    AmountDinar = eventData.AmountDinar,
                    AmountDollar = eventData.AmountDollar,
                    ClearanceCompanyId = eventData.ClearanceCompanyId,
                    TransactionName = eventData.TransactionName,
                    TransactionDetails = eventData.TransactionDetails,
                };
                await _clearanceCompanyCashFlowDomainService.InsertAsync(clearanceCompanyCashFlow);
            }
        }
    }
}
