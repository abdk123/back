using Abp.Events.Bus;
using Souccar.SaleManagement.PurchaseOrders.Deliveries;

namespace Souccar.SaleManagement.PurchaseInvoices.Events
{
    public class ChangeStatusEventData : EventData
    {
        public int InvoiceItemId { get; set; }
        public PurchaseInvoiceStatus Status { get; set; }
    }
}
