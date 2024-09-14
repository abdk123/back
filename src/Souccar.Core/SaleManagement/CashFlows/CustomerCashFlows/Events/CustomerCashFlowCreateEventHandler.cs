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
            double newCurrentBalanceDinar = 0;
            double newCurrentBalanceDollar = 0;

            var oldCurrentBalanceDinar = await _customerCashFlowDomainService.GetLastBalance(eventData.CustomerId, Currency.Dinar, DateTime.Now);
            var oldCurrentBalanceDollar = await _customerCashFlowDomainService.GetLastBalance(eventData.CustomerId, Currency.Dollar, DateTime.Now);

            newCurrentBalanceDinar = oldCurrentBalanceDinar + eventData.AmountDinar;
            newCurrentBalanceDollar = oldCurrentBalanceDollar + eventData.AmountDollar;

            var customerCashFlow = new CustomerCashFlow()
            {
                AmountDinar = eventData.AmountDinar,
                AmountDollar = eventData.AmountDollar,
                CustomerId = eventData.CustomerId,
                CurrentBalanceDinar = newCurrentBalanceDinar,
                CurrentBalanceDollar = newCurrentBalanceDollar,
                Note = eventData.Note,
                TransactionName = eventData.TransactionName,
                TransactionDetails = eventData.TransactionDetails,
            };

            await _customerCashFlowDomainService.InsertAsync(customerCashFlow);
        }
    }
}
