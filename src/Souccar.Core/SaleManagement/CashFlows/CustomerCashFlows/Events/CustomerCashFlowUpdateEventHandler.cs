using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events
{
    public class CustomerCashFlowUpdateEventHandler : IAsyncEventHandler<CustomerCashFlowUpdateEventData>, ITransientDependency
    {
        private readonly ICustomerCashFlowDomainService _customerCashFlowDomainService;

        public CustomerCashFlowUpdateEventHandler(ICustomerCashFlowDomainService customerCashFlowDomainService)
        {
            _customerCashFlowDomainService = customerCashFlowDomainService;
        }

        public async Task HandleEventAsync(CustomerCashFlowUpdateEventData eventData)
        {
            var cashFlow = await _customerCashFlowDomainService.
                FirstOrDefaultAsync(x=>x.RelatedId == eventData.RelatedId && x.TransactionName == eventData.TransactionName);
            
            if(cashFlow != null)
            {
                
                await _customerCashFlowDomainService.DeleteAsync(cashFlow.Id);
            }

            double newCurrentBalanceDinar = 0;
            double newCurrentBalanceDollar = 0;

            var oldCurrentBalanceDinar = await _customerCashFlowDomainService.GetLastBalance(eventData.CustomerId, Currency.Dinar, DateTime.Now);
            var oldCurrentBalanceDollar = await _customerCashFlowDomainService.GetLastBalance(eventData.CustomerId, Currency.Dollar, DateTime.Now);

            newCurrentBalanceDinar = oldCurrentBalanceDinar + eventData.AmountDinar;
            newCurrentBalanceDollar = oldCurrentBalanceDollar + eventData.AmountDollar;

            var customerCashFlow = new CustomerCashFlow()
            {
                RelatedId = eventData.RelatedId,
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
