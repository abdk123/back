using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events
{
    public class CustomerCashFlowCreateEventHandler : IAsyncEventHandler<CustomerCashFlowCreateEventData>, ITransientDependency
    {
        private readonly ICustomerCashFlowDomainService _customerCashFlowDomainService;

        public CustomerCashFlowCreateEventHandler(ICustomerCashFlowDomainService customerCashFlowDomainService)
        {
            _customerCashFlowDomainService = customerCashFlowDomainService;
        }

        public async Task HandleEventAsync(CustomerCashFlowCreateEventData eventData)
        {
           var cashFlow = await _customerCashFlowDomainService.GetCashFlow(eventData.CustomerId, eventData.RelatedId,eventData.TransactionName);
            if(cashFlow != null)
            {
                cashFlow.RelatedId = eventData.RelatedId;
                cashFlow.AmountDinar = eventData.AmountDinar;
                cashFlow.AmountDollar = eventData.AmountDollar;
                cashFlow.CustomerId = eventData.CustomerId;
                cashFlow.TransactionName = eventData.TransactionName;
                cashFlow.TransactionDetails = eventData.TransactionDetails;
                await _customerCashFlowDomainService.UpdateAsync(cashFlow);
            }
            else
            {
                var customerCashFlow = new CustomerCashFlow()
                {
                    RelatedId = eventData.RelatedId,
                    AmountDinar = eventData.AmountDinar,
                    AmountDollar = eventData.AmountDollar,
                    CustomerId = eventData.CustomerId,
                    TransactionName = eventData.TransactionName,
                    TransactionDetails = eventData.TransactionDetails,
                };
                await _customerCashFlowDomainService.InsertAsync(customerCashFlow);
            }
        }
    }
}
