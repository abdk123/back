using Abp.Events.Bus;

namespace Souccar.SaleManagement.PurchaseInvoices.Events
{
    public class ChangeStatusEventData : EventData
    {
        public int InvoiceItemId { get; set; }
        public PurchaseInvoiceStatus Status { get; set; }
    }
}
