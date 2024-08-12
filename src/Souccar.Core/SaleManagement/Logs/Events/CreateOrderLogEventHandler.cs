using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.Logs.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Logs.Events
{
    public class CreateOrderLogEventHandler : IAsyncEventHandler<CreateOrderLogEventData>, ITransientDependency
    {
        private readonly IOrderLogDomainService _orderLogDomainService;

        public CreateOrderLogEventHandler(IOrderLogDomainService orderLogDomainService)
        {
            _orderLogDomainService = orderLogDomainService;
        }

        public async Task HandleEventAsync(CreateOrderLogEventData eventData)
        {
            await _orderLogDomainService.InsertAsync(eventData.OrderLog);
        }
    }
}
