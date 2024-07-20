using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events
{
    public class CustomerCashFlowDeleteEventHandler : IAsyncEventHandler<CustomerCashFlowCreateEventData>, ITransientDependency
    {
        private readonly ICustomerCashFlowDomainService _customerCashFlowDomainService;

        public CustomerCashFlowDeleteEventHandler(ICustomerCashFlowDomainService customerCashFlowDomainService)
        {
            _customerCashFlowDomainService = customerCashFlowDomainService;
        }

        public async Task HandleEventAsync(CustomerCashFlowCreateEventData eventData)
        {
            var customerCashFlow = await _customerCashFlowDomainService.GetByInfo(eventData.CustomerId, eventData.AmountDollar, eventData.AmountDinar, eventData.TransactionDetails, eventData.Note, eventData.TransactionName);
            if (customerCashFlow != null)
            {
                await _customerCashFlowDomainService.DeleteAsync(customerCashFlow.Id);
            }
        }
    }
}
