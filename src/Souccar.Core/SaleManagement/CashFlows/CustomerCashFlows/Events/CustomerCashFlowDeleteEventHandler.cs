using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events
{
    public class CustomerCashFlowDeleteEventHandler : IAsyncEventHandler<CustomerCashFlowDeleteEventData>, ITransientDependency
    {
        private readonly ICustomerCashFlowDomainService _customerCashFlowDomainService;

        public CustomerCashFlowDeleteEventHandler(ICustomerCashFlowDomainService customerCashFlowDomainService)
        {
            _customerCashFlowDomainService = customerCashFlowDomainService;
        }

        public async Task HandleEventAsync(CustomerCashFlowDeleteEventData eventData)
        {
            var customerCashFlow = await _customerCashFlowDomainService.GetCashFlow(eventData.CustomerId, eventData.RelatedId, eventData.TransactionName);
            if (customerCashFlow != null)
            {
                await _customerCashFlowDomainService.DeleteAsync(customerCashFlow.Id);
            }
        }
    }
}
