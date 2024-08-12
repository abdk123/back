using Abp.Events.Bus;

namespace Souccar.SaleManagement.Logs.Events
{
    public class CreateOrderLogEventData : EventData
    {
        public OrderLog OrderLog { get; set; }

        public CreateOrderLogEventData(OrderLog orderLog)
        {
            OrderLog = orderLog;
        }
    }
}
