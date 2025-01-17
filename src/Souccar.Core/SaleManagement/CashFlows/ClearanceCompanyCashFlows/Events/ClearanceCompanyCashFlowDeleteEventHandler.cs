﻿using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events
{
    public class ClearanceCompanyCashFlowDeleteEventHandler : IAsyncEventHandler<ClearanceCompanyCashFlowDeleteEventData>, ITransientDependency
    {
        private readonly IClearanceCompanyCashFlowDomainService _clearanceCompanyCashFlowDomainService;

        public ClearanceCompanyCashFlowDeleteEventHandler(IClearanceCompanyCashFlowDomainService clearanceCompanyCashFlowDomainService)
        {
            _clearanceCompanyCashFlowDomainService = clearanceCompanyCashFlowDomainService;
        }

        public async Task HandleEventAsync(ClearanceCompanyCashFlowDeleteEventData eventData)
        {
            var clearanceCompanyCashFlow = await _clearanceCompanyCashFlowDomainService.GetCashFlow(eventData.ClearanceCompanyId,eventData.RelatedId, eventData.TransactionName);
            if(clearanceCompanyCashFlow != null)
            {
                await _clearanceCompanyCashFlowDomainService.DeleteAsync(clearanceCompanyCashFlow.Id);
            }
        }
    }
}
