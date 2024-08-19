using Abp.Events.Bus;
using Souccar.SaleManagement.PurchaseOrders.Deliveries;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Events
{
    public class ChangeStatusEventData : EventData
    {
        public int InvoiceItemId { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}
