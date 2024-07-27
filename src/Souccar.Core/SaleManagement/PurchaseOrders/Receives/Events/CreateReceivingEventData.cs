using Abp.Events.Bus;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Events
{
    public class CreateReceivingEventData :EventData
    {
        public int InvoiceId { get; set; }
        public IList<InvoiceItem> InvoiceItems { get; set; }
    }
}
