﻿using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Linq;
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
            var cashFlow = await _clearanceCompanyCashFlowDomainService.
                FirstOrDefaultAsync(x=>x.RelatedId == eventData.RelatedId && x.TransactionName == eventData.TransactionName);
            
            if(cashFlow == null)
            {
                await CreateClearanceCompanyCashFlowAsync(eventData);
            }

        }

        private async Task CreateClearanceCompanyCashFlowAsync(ClearanceCompanyCashFlowCreateEventData eventData)
        {
            double newCurrentBalanceDinar = 0;
            double newCurrentBalanceDollar = 0;

            var oldCurrentBalanceDinar = await _clearanceCompanyCashFlowDomainService.GetLastBalance(eventData.ClearanceCompanyId, Currency.Dinar, DateTime.Now);
            var oldCurrentBalanceDollar = await _clearanceCompanyCashFlowDomainService.GetLastBalance(eventData.ClearanceCompanyId, Currency.Dollar, DateTime.Now);

            newCurrentBalanceDinar = oldCurrentBalanceDinar + eventData.AmountDinar;
            newCurrentBalanceDollar = oldCurrentBalanceDollar + eventData.AmountDollar;

            var clearanceCompanyCashFlow = new ClearanceCompanyCashFlow()
            {RelatedId = eventData.RelatedId,
                AmountDinar = eventData.AmountDinar,
                AmountDollar = eventData.AmountDollar,
                ClearanceCompanyId = eventData.ClearanceCompanyId,
                CurrentBalanceDinar = newCurrentBalanceDinar,
                CurrentBalanceDollar = newCurrentBalanceDollar,
                Note = eventData.Note,
                TransactionName = eventData.TransactionName,
                TransactionDetails = eventData.TransactionDetails,
            };

            await _clearanceCompanyCashFlowDomainService.InsertAsync(clearanceCompanyCashFlow);

        }
    }
}
